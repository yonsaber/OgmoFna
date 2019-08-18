using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using OgmoPipelineExtension.ContentItems.Values;

namespace OgmoPipelineExtension.ContentItems
{
    public class ObjectContent
    {
        public int Height;
        public bool IsTiled;
        public string Name;
        public List<NodeContent> Nodes = new List<NodeContent>();
        public Vector2 Origin;
        public Vector2 Position;
        public float Rotation;
        public Rectangle Source;
        public ExternalReference<TextureContent> TextureReference;
        public List<ValueContent> Values = new List<ValueContent>();
        public int Width;

        public ObjectContent()
        {
        }

        public ObjectContent(XmlNode node, ObjectTemplateContent template)
        {
            Name = node.Name;
            TextureReference = template.TextureReference;
            IsTiled = template.IsTiled;
            Origin = template.Origin;
            Source = template.Source;
            if (node.Attributes["height"] != null)
                Height = int.Parse(node.Attributes["height"].Value, CultureInfo.InvariantCulture);
            else
                Height = template.Height;
            if (node.Attributes["x"] != null)
                Position.X = int.Parse(node.Attributes["x"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["y"] != null)
                Position.Y = int.Parse(node.Attributes["y"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["width"] != null)
                Width = int.Parse(node.Attributes["width"].Value, CultureInfo.InvariantCulture);
            else
                Width = template.Width;
            if (node.Attributes["angle"] != null)
                Rotation = float.Parse(node.Attributes["angle"].Value, CultureInfo.InvariantCulture);
            if (IsTiled)
            {
                Source.Width = Width;
                Source.Height = Height;
            }
        }
    }
}
