using Microsoft.Xna.Framework.Content.Pipeline;
using OgmoPipelineExtension.ContentItems;

namespace OgmoPipelineExtension
{
    [ContentImporter(".oel", DisplayName = "Ogmo Editor Level Importer", DefaultProcessor = "OelProcessor")]
    public class OelImporter : ContentImporter<OelContent>
    {
        public override OelContent Import(string filename, ContentImporterContext context)
        {
            char slashType = '/';

            if (filename.Contains("\\"))
            {
                slashType = '\\';
            }

            OelContent content = new OelContent
            {
                Document = new System.Xml.XmlDocument(),
                Directory = filename.Remove(filename.LastIndexOf(slashType)),
                Filename = filename
            };
            content.Document.Load(filename);
            return content;
        }
    }
}
