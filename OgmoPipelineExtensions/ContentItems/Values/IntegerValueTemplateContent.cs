using System.Globalization;
using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Values
{
    public class IntegerValueTemplateContent : ValueTemplateContent<int>
    {
        public int Max;
        public int Min;

        public IntegerValueTemplateContent()
        {
        }

        public IntegerValueTemplateContent(XmlNode node)
            : base(node)
        {
            if (node.Attributes["default"] != null)
                Default = int.Parse(node.Attributes["default"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["max"] != null)
                Max = int.Parse(node.Attributes["max"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["min"] != null)
                Min = int.Parse(node.Attributes["min"].Value, CultureInfo.InvariantCulture);
        }
    }
}
