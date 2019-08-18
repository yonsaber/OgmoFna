using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Values
{
    public class NumberValueContent : ValueContent<float>
    {
        public NumberValueContent()
            : base()
        {
        }

        public NumberValueContent(XmlNode node)
            : base(node)
        {
        }

        public NumberValueContent(string name, float value)
            : base()
        {
            Name = name;
            Value = value;
        }
    }
}
