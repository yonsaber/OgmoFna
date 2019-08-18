using System.Xml;

namespace OgmoPipelineExtension.ContentItems.Layers.Settings
{
    public class TileLayerSettingsContent : LayerSettingsContent
    {
        public bool ExportTileIDs;
        public bool ExportTileSize;
        public bool MultipleTilesets;

        public TileLayerSettingsContent()
        {
        }

        public TileLayerSettingsContent(XmlNode node)
            : base(node)
        {
            if (node.Attributes["exportTileIDs"] != null)
                ExportTileIDs = bool.Parse(node.Attributes["exportTileIDs"].Value);
            if (node.Attributes["exportTileSize"] != null)
                ExportTileSize = bool.Parse(node.Attributes["exportTileSize"].Value);
            if (node.Attributes["multipleTilesets"] != null)
                MultipleTilesets = bool.Parse(node.Attributes["multipleTilesets"].Value);
        }
    }
}
