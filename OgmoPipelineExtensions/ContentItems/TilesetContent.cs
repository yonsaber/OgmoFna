using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using System.Xml;
using Microsoft.Xna.Framework;

namespace OgmoPipelineExtensions.ContentItems
{
    public class TilesetContent
    {
        public string Name;
        public string FilePath;
        public Vector2 TileSize;
        public int TileStep;
        public ExternalReference<TextureContent> TextureReference;

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
                FilePath = fileNode.InnerText;
            }

            XmlNode sizeNode = node["TileSize"];

            TileSize = sizeNode.ReadWidthHeightToVec2();
        }
    }
}
