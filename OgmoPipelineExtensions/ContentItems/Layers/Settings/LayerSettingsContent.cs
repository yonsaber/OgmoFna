using System.Globalization;
using System.Xml;
using Microsoft.Xna.Framework;

namespace OgmoPipelineExtension.ContentItems.Layers.Settings
{
    public abstract class LayerSettingsContent
    {
        public Color GridColor;
        public int GridDrawSize;
        public int GridSize;
        public string Name;

        public LayerSettingsContent()
        {
        }

        public LayerSettingsContent(XmlNode node)
        {
            if (node.Attributes["gridColor"] != null)
                GridColor = ColorHelper.FromHex(node.Attributes["gridColor"].Value);
            if (node.Attributes["drawGridSize"] != null)
                GridDrawSize = int.Parse(node.Attributes["drawGridSize"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["gridSize"] != null)
                GridSize = int.Parse(node.Attributes["gridSize"].Value, CultureInfo.InvariantCulture);
            if (node.Attributes["name"] != null)
                Name = node.Attributes["name"].Value;
        }
    }
}
