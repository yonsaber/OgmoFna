using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Layers.Settings
{
    public class GridLayerSettingsContent : LayerSettingsContent
    {
        public bool ExportAsObjects;
        public string NewLine;

        public GridLayerSettingsContent()
        {
        }

        public GridLayerSettingsContent(XmlNode node)
            : base(node)
        {
            if (node.Attributes["exportAsObjects"] != null)
                ExportAsObjects = bool.Parse(node.Attributes["exportAsObjects"].Value);
            if (node.Attributes["newLine"] != null)
                NewLine = node.Attributes["newLine"].Value;
            NewLine = NewLine ?? "\n";                
        }
    }
}
