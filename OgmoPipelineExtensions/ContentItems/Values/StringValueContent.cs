using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Values
{
    public class StringValueContent : ValueContent<string>
    {
        public StringValueContent()
            : base()
        {
        }

        public StringValueContent(XmlNode node)
            : base(node)
        {

        }

        public StringValueContent(string name, string value)
            : base()
        {
            Name = name;
            Value = value;
        }
    }
}
