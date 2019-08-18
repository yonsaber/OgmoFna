using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using System.Xml;
using System.Globalization;

namespace OgmoPipelineExtension.ContentItems
{
    public class TilesetContent
    {
        public string Name;
        public string TextureFile;
        public ExternalReference<TextureContent> TextureReference;
        public int TileHeight;
        public int TileWidth;

        public TilesetContent()
        {
        }

        public TilesetContent(XmlNode node)
        {
            if (node.Attributes["name"] != null)
                Name = node.Attributes["name"].Value;
            if (node.Attributes["image"] != null)
                TextureFile = node.Attributes["image"].Value;
            if (node.Attributes["tileHeight"] != null)
                TileHeight = int.Parse(node.Attributes["tileHeight"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["tileWidth"] != null)
                TileWidth = int.Parse(node.Attributes["tileWidth"].Value, CultureInfo.InvariantCulture);
        }
    }
}
