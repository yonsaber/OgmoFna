using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Values
{
    public class BooleanValueTemplateContent : ValueTemplateContent<bool>
    {
        public BooleanValueTemplateContent()
        {
        }

        public BooleanValueTemplateContent(XmlNode node)
            : base(node)
        {
            if (node.Attributes["default"] != null)
                Default = bool.Parse(node.Attributes["default"].Value);
        }
    }
}
