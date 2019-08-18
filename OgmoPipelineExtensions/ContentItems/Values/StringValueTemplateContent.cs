using System.Globalization;
using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Values
{
    public class StringValueTemplateContent : ValueTemplateContent<string>
    {
        public int MaxChars;

        public StringValueTemplateContent()
        {
        }

        public StringValueTemplateContent(XmlNode node)
            : base(node)
        {
            if (node.Attributes["default"] != null)
                Default = node.Attributes["default"].Value;
            if (node.Attributes["maxChars"] != null)
                MaxChars = int.Parse(node.Attributes["maxChars"].Value, CultureInfo.InvariantCulture);
        }
    }
}
