using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Values
{
    static class ValueContentTemplateParser
    {
        internal static ValueTemplateContent Parse(XmlNode node)
        {
            ValueTemplateContent valueContent = null;
            switch (node.Name)
            {
                case "boolean":
                    valueContent = new BooleanValueTemplateContent(node);
                    break;
                case "integer":
                    valueContent = new IntegerValueTemplateContent(node);
                    break;
                case "number":
                    valueContent = new NumberValueTemplateContent(node);
                    break;
                case "string":
                // Fallthrough.
                case "text":
                    valueContent = new StringValueTemplateContent(node);
                    break;
            }
            return valueContent;
        }
    }
}
