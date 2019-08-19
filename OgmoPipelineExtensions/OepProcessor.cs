using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using OgmoPipelineExtension.ContentItems;
using System.IO;

namespace OgmoPipelineExtension
{
    [ContentProcessor(DisplayName = "Ogmo Editor Project Processor")]
    public class OepProcessor : ContentProcessor<OepContent, ProjectContent>
    {
        public override ProjectContent Process(OepContent input, ContentProcessorContext context)
        {
            ProjectContent projectContent = new ProjectContent(input.Document);
            string workingDirectory = Path.GetFullPath(Path.Combine(input.Directory, projectContent.Filename, "..\\"));
            foreach (TilesetContent tileset in projectContent.Tilesets)
            {
                string assetPath = Path.Combine(workingDirectory, tileset.TextureFile);
                string asset = assetPath.Remove(assetPath.LastIndexOf('.')).Substring(Directory.GetCurrentDirectory().Length + 1);
                OpaqueDataDictionary data = new OpaqueDataDictionary
                {
                    { "GenerateMipmaps", false },
                    { "ResizeToPowerOfTwo", false },
                    { "TextureFormat", TextureProcessorOutputFormat.Color },
                    { "ColorKeyEnabled", false },
                    { "ColorKeyColor", Microsoft.Xna.Framework.Color.Magenta }
                };
                tileset.TextureReference = context.BuildAsset<TextureContent, TextureContent>(
                    new ExternalReference<TextureContent>(assetPath),
                    "TextureProcessor",
                    data,
                    "TextureImporter",
                    asset);
            }
            foreach (ObjectTemplateContent obj in projectContent.Objects)
            {
                string assetPath = Path.Combine(workingDirectory, obj.TextureFile);
                string asset = assetPath.Remove(assetPath.LastIndexOf('.')).Substring(Directory.GetCurrentDirectory().Length + 1);
                OpaqueDataDictionary data = new OpaqueDataDictionary
                {
                    { "GenerateMipmaps", false },
                    { "ResizeToPowerOfTwo", false },
                    { "TextureFormat", TextureProcessorOutputFormat.Color },
                    { "ColorKeyEnabled", false },
                    { "ColorKeyColor", Microsoft.Xna.Framework.Color.Magenta }
                };
                obj.TextureReference = context.BuildAsset<TextureContent, TextureContent>(
                    new ExternalReference<TextureContent>(assetPath),
                    "TextureProcessor",
                    data,
                    "TextureImporter",
                    asset);
            }
            return projectContent;
        }
    }
}