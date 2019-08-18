using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Layers.Settings
{
    static class LayerSettingsNodeReader
    {
        internal static LayerSettingsContent Read(XmlNode node)
        {
            LayerSettingsContent content = null;
            switch (node.Name)
            {
                case "grid":
                    content = new GridLayerSettingsContent(node);
                    break;
                case "tiles":
                    content = new TileLayerSettingsContent(node);
                    break;
                case "objects":
                    content = new ObjectLayerSettingsContent(node);
                    break;
            }
            return content;
        }
    }
}
