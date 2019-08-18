using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Values
{
    public abstract class ValueTemplateContent<T> : ValueTemplateContent
    {
        public T Default;

        protected ValueTemplateContent()
            : base()
        {
        }

        protected ValueTemplateContent(XmlNode node)
            : base(node)
        {
        }
    }
}
