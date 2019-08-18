using System.Collections.Generic;
using System.Xml;
using OgmoPipelineExtension.ContentItems.Layers.Settings;
using OgmoPipelineExtension.ContentItems.Values;

namespace OgmoPipelineExtension.ContentItems
{
    public class ProjectContent
    {
        public List<LayerSettingsContent> LayerSettings = new List<LayerSettingsContent>();
        public string Name;
        public List<ObjectTemplateContent> Objects = new List<ObjectTemplateContent>();
        public ProjectSettingsContent Settings;
        public List<TilesetContent> Tilesets = new List<TilesetContent>();
        public List<ValueTemplateContent> Values = new List<ValueTemplateContent>();

        public ProjectContent()
        {
        }

        public ProjectContent(XmlDocument document)
        {
            XmlNode projectNode = document["project"];
            // Name
            XmlNode nameNode = projectNode.SelectSingleNode("name");
            if (nameNode != null)
                Name = nameNode.InnerText;
            // Settings
            XmlNode settingsNode = projectNode.SelectSingleNode("settings");
            if (settingsNode != null)
                Settings = new ProjectSettingsContent(settingsNode);
            else
                Settings = new ProjectSettingsContent();
            // Values
            XmlNode valuesNode = projectNode.SelectSingleNode("values");
            if (valuesNode != null)
            {
                foreach (XmlNode valueNode in valuesNode.ChildNodes)
                {
                    ValueTemplateContent valueContent = ValueContentTemplateParser.Parse(valueNode);
                    if (valueContent != null)
                        Values.Add(valueContent);
                }
            }
            // Tilesets
            XmlNode tilesetsNode = projectNode.SelectSingleNode("tilesets");
            if (tilesetsNode != null)
            {
                foreach (XmlNode childNode in tilesetsNode)
                    Tilesets.Add(new TilesetContent(childNode));
            }
            // Objects
            XmlNode objectsNode = projectNode.SelectSingleNode("objects");
            if (objectsNode != null)
            {
                foreach (XmlNode childNode in objectsNode.SelectNodes("object|folder/object"))
                    Objects.Add(new ObjectTemplateContent(childNode));
            }   
            // Layer Settings
            XmlNode layerSettingsNode = projectNode.SelectSingleNode("layers");
            if (layerSettingsNode != null)
            {
                foreach (XmlNode childNode in layerSettingsNode.ChildNodes)
                {
                    LayerSettingsContent layerSettingsContent = LayerSettingsContentParser.Parse(childNode);
                    if (layerSettingsContent != null)
                        LayerSettings.Add(layerSettingsContent);
                }
            }
        }
    }
}
