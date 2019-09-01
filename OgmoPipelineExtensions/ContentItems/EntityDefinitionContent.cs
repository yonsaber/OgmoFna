using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using System.Xml;

namespace OgmoPipelineExtensions
{
    public class EntityDefinitionContent
    {
        public string Name;
        public int Limit;
        public bool ResizableX;
        public bool ResizableY;
        public bool Rotatable;
        public int RotateIncrement;

        public Vector2 Size;
        public Vector2 Origin;
        //public EntityImageDefinition ImageDefinition;
        //public List<ValueDefinition> ValueDefinitions;
        //public EntityNodesDefinition NodesDefinition;
        //public ExternalReference<TextureContent> TextureReference;

        public EntityDefinitionContent(XmlNode node)
        {
            Name = node.Attributes["Name"]?.InnerText;
            node.ReadAsInt("Limit", out Limit);
            node.ReadAsBool("ResizableX", out ResizableX);
            node.ReadAsBool("ResizableY", out ResizableY);
            node.ReadAsBool("Rotatable", out Rotatable);
            node.ReadAsInt("RotateIncrement", out RotateIncrement);
            Size = node.ReadWidthHeightToVec2("Size");
            Origin = node.ReadXYToVec2("Origin");
        }
    }
}
