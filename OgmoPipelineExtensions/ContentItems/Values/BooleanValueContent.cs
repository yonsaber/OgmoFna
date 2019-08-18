using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Values
{
    public class BooleanValueContent : ValueContent<bool>
    {
        public BooleanValueContent()
            : base()
        {
        }

        public BooleanValueContent(XmlNode node)
            : base(node)
        {
        }

        public BooleanValueContent(string name, bool value)
            : base()
        {
            Name = name;
            Value = value;
        }
    }
}
