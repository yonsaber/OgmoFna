using Microsoft.Xna.Framework;
using System;
using System.Xml;

namespace OgmoPipelineExtensions.ContentItems
{
    public class LayerDefinitionContent
    {
        public string Name;
        public Vector2 Grid;
        public Vector2 ScrollFactor;
        public Color Color;
        public ExportMode ExportMode;

        public LayerDefinitionContent() {}

        public LayerDefinitionContent(XmlNode node)
        {
            XmlNode nameNode = node.SelectSingleNode("Name");
            if (nameNode != null)
            {
                Name = nameNode.InnerText;
            }

            Grid = node.ReadWidthHeightToVec2("Grid");

            ScrollFactor = node.ReadXYToVec2("ScrollFactor");

            XmlNode exportTypeNode = node.SelectSingleNode("ExportMode");
            if (exportTypeNode != null)
            {
                Enum.TryParse(exportTypeNode.InnerText, out ExportMode exportMode);
                ExportMode = exportMode;
            }
        }
    }

    public enum ExportMode
    {
        XMLCoords,
        CSV,
        Bitstring,
    }
}
