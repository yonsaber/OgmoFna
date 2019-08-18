using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Values
{
    public abstract class ValueTemplateContent
    {
        public string Name;

        protected ValueTemplateContent()
        {
        }

        protected ValueTemplateContent(XmlNode node)
        {
            if(node.Attributes["name"] != null)
                Name = node.Attributes["name"].Value;
        }
    }
}
