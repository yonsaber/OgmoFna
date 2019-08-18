using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Values
{
    public class IntegerValueContent : ValueContent<int>
    {
        public IntegerValueContent()
            : base()
        {
        }

        public IntegerValueContent(XmlNode node)
            : base(node)
        {
        }

        public IntegerValueContent(string name, int value)
            : base()
        {
            Name = name;
            Value = value;
        }
    }
}
