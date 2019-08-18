using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Layers
{
    public abstract class LayerContent
    {
        public string Name;

        public LayerContent()
        {
        }

        public LayerContent(XmlNode node)
        {
            Name = node.Name;
        }
    }
}
