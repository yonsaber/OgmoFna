using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using OgmoPipelineExtension.ContentItems.Values;

namespace OgmoPipelineExtension.ContentItems
{
    public class ObjectTemplateContent
    {
        public int Height;
        public bool IsResizableX;
        public bool IsResizableY;
        public bool IsTiled;
        public string Name;
        public Vector2 Origin;
        public Rectangle Source;
        public string TextureFile;
        public ExternalReference<TextureContent> TextureReference;
        public int Width;
        public List<ValueTemplateContent> Values = new List<ValueTemplateContent>();

        public ObjectTemplateContent()
        {
        }

        public ObjectTemplateContent(XmlNode node)
        {
            if (node.Attributes["height"] != null)
                Height = int.Parse(node.Attributes["height"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["width"] != null)
                Width = int.Parse(node.Attributes["width"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["resizableX"] != null)
                IsResizableX = bool.Parse(node.Attributes["resizableX"].Value);
            if (node.Attributes["resizableY"] != null)
                IsResizableY = bool.Parse(node.Attributes["resizableY"].Value);
            if (node.Attributes["tile"] != null)
                IsTiled = bool.Parse(node.Attributes["tile"].Value);
            if (node.Attributes["name"] != null)
                Name = node.Attributes["name"].Value;
            if (node.Attributes["originX"] != null)
                Origin.X = int.Parse(node.Attributes["originX"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["originY"] != null)
                Origin.Y = int.Parse(node.Attributes["originY"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["imageOffsetX"] != null)
                Source.X = int.Parse(node.Attributes["imageOffsetX"].Value, CultureInfo.InvariantCulture);
            else
                Source.X = 0;
            if (node.Attributes["imageOffsetY"] != null)
                Source.Y = int.Parse(node.Attributes["imageOffsetY"].Value, CultureInfo.InvariantCulture);
            else
                Source.Y = 0;
            if (node.Attributes["imageWidth"] != null)
                Source.Width = int.Parse(node.Attributes["imageWidth"].Value, CultureInfo.InvariantCulture);
            else
                Source.Width = Width;
            if (node.Attributes["imageHeight"] != null)
                Source.Height = int.Parse(node.Attributes["imageHeight"].Value, CultureInfo.InvariantCulture);
            else
                Source.Height = Height;
            if (node.Attributes["image"] != null)
                TextureFile = node.Attributes["image"].Value;
            // Values
            XmlNode valuesNode = node.SelectSingleNode("values");
            if (valuesNode != null)
            {
                foreach (XmlNode valueNode in valuesNode.SelectNodes("boolean|integer|number|string|text"))
                {
                    ValueTemplateContent valueContent = ValueContentTemplateParser.Parse(valueNode);
                    if (valueContent != null)
                        Values.Add(valueContent);
                }
            }
        }
    }
}
