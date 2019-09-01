using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.Xna.Framework;

namespace OgmoPipelineExtensions.ContentItems
{
    public class ProjectContent
    {
        public string Name;
        public string Filename;
        public string VersionNumber;
        public Color BackgroundColor;
        public Color GridColor;
        public string AngleMode;
        public bool CameraEnabled;
        public bool ExportCameraPosition;
        public Vector2 LevelDefaultSize;
        public Vector2 LevelMinimumSize;
        public Vector2 LevelMaximumSize;
        public Vector2 CameraSize;

        //public List<ValueDefinition> LevelValueDefinitions;
        public List<LayerDefinitionContent> LayerDefinitions;
        public List<TilesetContent> Tilesets;
        public List<EntityDefinitionContent> EntityDefinitions;

        public ProjectContent()
        {
        }

        public ProjectContent(XmlDocument document)
        {
            XmlNode projectNode = document["project"];

            VersionNumber = projectNode.SelectSingleNode("OgmoVersion")?.InnerText;

            Name = projectNode.SelectSingleNode("//*[translate(name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'name']")?.InnerText;
            Filename = projectNode.SelectSingleNode("Filename")?.InnerText;
            AngleMode = projectNode.SelectSingleNode("AngleMode")?.InnerText;
            CameraEnabled = projectNode.SelectSingleNode("CameraEnabled")?.InnerText.ToLower() == "false" ? false : true;
            ExportCameraPosition = projectNode.SelectSingleNode("ExportCameraPosition")?.InnerText.ToLower() == "false" ? false : true;
            BackgroundColor = ColorHelper.FromRGBAAttributes(projectNode, "BackgroundColor");
            GridColor = ColorHelper.FromRGBAAttributes(projectNode, "GridColor");

            LevelDefaultSize = projectNode.ReadWidthHeightToVec2("LevelDefaultSize");
            LevelMinimumSize = projectNode.ReadWidthHeightToVec2("LevelMinimumSize");
            LevelMaximumSize = projectNode.ReadWidthHeightToVec2("LevelMaximumSize");
            CameraSize = projectNode.ReadWidthHeightToVec2("CameraSize");

            // LevelValueDefinitions
            //XmlNode levelValueNode = projectNode.SelectSingleNode("LevelValueDefinitions");
            //LevelValueDefinitions = new List<LevelValueDefinitions>();
            //foreach (XmlNode valueDefinition in levelValueNode.SelectNodes("LevelValueDefinition"))
            //{
            //    LevelValueDefinitions.Add(new LevelValueDefinitions().ReadFromXml(valueDefinition));
            //}

            // LayerDefinitions
            XmlNode layerDefinitionNode = projectNode.SelectSingleNode("LayerDefinitions");
            LayerDefinitions = new List<LayerDefinitionContent>();
            foreach (XmlNode layerDefinition in layerDefinitionNode.SelectNodes("LayerDefinition"))
            {
                LayerDefinitions.Add(new LayerDefinitionContent(layerDefinition));
            }

            // Tilesets
            XmlNode tileSetNode = projectNode.SelectSingleNode("Tilesets");
            Tilesets = new List<TilesetContent>();
            foreach (XmlNode tileSet in tileSetNode.SelectNodes("Tileset"))
            {
                Tilesets.Add(new TilesetContent(tileSet));
            }

            // EntityDefinitions
            XmlNode entityDefinitionNode = projectNode.SelectSingleNode("EntityDefinitions");
            EntityDefinitions = new List<EntityDefinitionContent>();
            foreach (XmlNode entityDefinition in entityDefinitionNode.SelectNodes("EntityDefinition"))
            {
                EntityDefinitions.Add(new EntityDefinitionContent(entityDefinition));
            }
        }
    }
}
