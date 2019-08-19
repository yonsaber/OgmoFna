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
            XmlNode nameNode = node.SelectSingleNode("Name");
            if (nameNode != null)
            {
                Name = nameNode.InnerText;
            }

            XmlNode fileNode = node.SelectSingleNode("FilePath");
            if (fileNode != null)
            {
                TextureFile = fileNode.InnerText;
            }

            XmlNode sizeNode = node["TileSize"];

            XmlNode heightNode = node.SelectSingleNode("Height");
            if (heightNode != null)
            {
                TileHeight = int.Parse(heightNode.InnerText, CultureInfo.InvariantCulture);
            }

            XmlNode widthNode = node.SelectSingleNode("Width");
            if (widthNode != null)
            {
                TileHeight = int.Parse(widthNode.InnerText, CultureInfo.InvariantCulture);
            }
        }
    }
}
