using Microsoft.Xna.Framework.Content.Pipeline;
using OgmoPipelineExtension.ContentItems;

namespace OgmoPipelineExtension
{
    [ContentImporter(".oep", DisplayName = "Ogmo Editor Project Importer", DefaultProcessor = "OepProcessor")]
    public class OepImporter : ContentImporter<OepContent>
    {
        public override OepContent Import(string filename, ContentImporterContext context)
        {
            char slashType = '/';

            if (filename.Contains("\\"))
            {
                slashType = '\\';
            }

            OepContent content = new OepContent
            {
                Document = new System.Xml.XmlDocument(),
                Directory = filename.Remove(filename.LastIndexOf(slashType)),
                Filename = filename,
            };
            content.Document.Load(filename);
            return content;
        }
    }
}
