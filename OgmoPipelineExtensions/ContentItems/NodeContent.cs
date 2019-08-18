using System.Xml;
using Microsoft.Xna.Framework;
using System.Globalization;

namespace OgmoPipelineExtension.ContentItems
{
    public class NodeContent
    {
        public Vector2 Position;

        public NodeContent()
        {
        }

        public NodeContent(XmlNode node)
        {
            if (node.Attributes["x"] != null)
                Position.X = int.Parse(node.Attributes["x"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["y"] != null)
                Position.Y = int.Parse(node.Attributes["y"].Value, CultureInfo.InvariantCulture);
        }
    }
}
