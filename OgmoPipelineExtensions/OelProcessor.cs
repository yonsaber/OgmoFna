using System;
using System.ComponentModel;
using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;
using OgmoPipelineExtension.ContentItems;

namespace OgmoPipelineExtension
{
    [ContentProcessor(DisplayName = "Ogmo Editor Level Processor")]
    public class OelProcessor : ContentProcessor<OelContent, LevelContent>
    {
        [DisplayName("Project File")]
        [Description("A relative path to the project file associated with this level.")]
        public string OgmoProjectFile { get; set; }

        public override LevelContent Process(OelContent input, ContentProcessorContext context)
        {
            if (string.IsNullOrEmpty(OgmoProjectFile))
                throw new Exception("No project file specified.");
            if (!OgmoProjectFile.EndsWith(".oep"))
                OgmoProjectFile += ".oep";
            string projectPath = Path.GetFullPath(Path.Combine(input.Directory, OgmoProjectFile));
            string projectAsset = projectPath.Remove(projectPath.LastIndexOf('.')).Substring(Directory.GetCurrentDirectory().Length + 1);
            ProjectContent projectContent = context.BuildAndLoadAsset<OepContent, ProjectContent>(
                new ExternalReference<OepContent>(projectPath),
                "OepProcessor",
                new OpaqueDataDictionary(),
                "OepImporter");
            LevelContent levelContent = new LevelContent(projectContent, input.Document);
            levelContent.ProjectReference = context.BuildAsset<OepContent, ProjectContent>(
                new ExternalReference<OepContent>(projectPath),
                "OepProcessor",
                new OpaqueDataDictionary(),
                "OepImporter",
                projectAsset);
            return levelContent;
        }
    }
}