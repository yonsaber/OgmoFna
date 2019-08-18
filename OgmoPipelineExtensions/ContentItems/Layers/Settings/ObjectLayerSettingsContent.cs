using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Layers.Settings
{
    public class ObjectLayerSettingsContent : LayerSettingsContent
    {
        public ObjectLayerSettingsContent()
        {
        }

        public ObjectLayerSettingsContent(XmlNode node)
            : base(node)
        {
        }
    }
}
