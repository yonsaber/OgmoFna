using System.Globalization;
using System.Xml;
using Microsoft.Xna.Framework;
using OgmoPipelineExtension.ContentItems.Layers.Settings;

namespace OgmoPipelineExtension.ContentItems.Layers
{
    public class TileContent
    {
        public int Height;
        public Vector2 Position = Vector2.Zero;
        public Vector2 TextureOffset;
        public int SourceIndex;
        public string TilesetName;
        public int Width;

        public TileContent()
        {
        }

        public TileContent(XmlNode node, TileLayerContent layer, TileLayerSettingsContent settings)
        {
            if (!settings.MultipleTilesets && !settings.ExportTileSize)
            {
                Height = layer.TileHeight;
                Width = layer.TileWidth;
            }
            else if(settings.MultipleTilesets || settings.ExportTileSize) 
            {
                if (node.Attributes["th"] != null)
                    Height = int.Parse(node.Attributes["th"].Value, CultureInfo.InvariantCulture);
                if (node.Attributes["tw"] != null)
                    Width = int.Parse(node.Attributes["tw"].Value, CultureInfo.InvariantCulture);
            }
            if (node.Attributes["x"] != null)
                Position.X = int.Parse(node.Attributes["x"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["y"] != null)
                Position.Y = int.Parse(node.Attributes["y"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["tx"] != null)
                TextureOffset.X = int.Parse(node.Attributes["tx"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["ty"] != null)
                TextureOffset.Y = int.Parse(node.Attributes["ty"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["id"] != null)
                SourceIndex = int.Parse(node.Attributes["id"].Value, CultureInfo.InvariantCulture);
            if (settings.MultipleTilesets)
            {
                if (node.Attributes["set"] != null)
                    TilesetName = node.Attributes["set"].Value;
            }
            else
                TilesetName = layer.Tilesets[0];
        }
    }
}
