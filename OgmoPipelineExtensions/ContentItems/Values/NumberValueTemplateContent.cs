using System.Globalization;
using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Values
{
    public class NumberValueTemplateContent : ValueTemplateContent<float>
    {
        public float Max;
        public float Min;

        public NumberValueTemplateContent()
        {
        }

        public NumberValueTemplateContent(XmlNode node)
            : base(node)
        {
            if (node.Attributes["default"] != null)
                Default = float.Parse(node.Attributes["default"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["max"] != null)
                Max = float.Parse(node.Attributes["max"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["min"] != null)
                Min = float.Parse(node.Attributes["min"].Value, CultureInfo.InvariantCulture);
        }
    }
}
