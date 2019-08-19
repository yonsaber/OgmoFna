using System.Collections.Generic;
using System.Xml;
using Microsoft.Xna.Framework;
using OgmoPipelineExtension.ContentItems.Layers.Settings;
using OgmoPipelineExtension.ContentItems.Values;

namespace OgmoPipelineExtension.ContentItems
{
    public class ProjectContent
    {
        public string Name;
        public string VersionNumber;
        public Color BackgroundColor;
        public Color GridColor;
        public string Filename;

        public List<LayerSettingsContent> LayerSettings = new List<LayerSettingsContent>();
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

            XmlNode versionNode = projectNode.SelectSingleNode("OgmoVersion");
            if (versionNode != null)
            {
                VersionNumber = versionNode.InnerText;
                System.Diagnostics.Debug.WriteLine($"Ogmo Version: {VersionNumber}");
            }

            // Name
            XmlNode nameNode = projectNode.SelectSingleNode("Name");
            if (nameNode != null)
            {
                Name = nameNode.InnerText;
            }

            // Filename
            XmlNode fileNameNode = projectNode.SelectSingleNode("Filename");
            if (fileNameNode != null)
            {
                Filename = fileNameNode.InnerText;
            }

            // Values
            XmlNode valuesNode = projectNode.SelectSingleNode("Values");
            if (valuesNode != null)
            {
                foreach (XmlNode valueNode in valuesNode.ChildNodes)
                {
                    ValueTemplateContent valueContent = ValueContentTemplateParser.Parse(valueNode);
                    if (valueContent != null)
                    {
                        Values.Add(valueContent);
                    }
                }
            }

            // Tilesets
            XmlNode tilesetsNode = projectNode.SelectSingleNode("Tilesets");
            if (tilesetsNode != null)
            {
                foreach (XmlNode childNode in tilesetsNode)
                {
                    Tilesets.Add(new TilesetContent(childNode));
                }
            } 

            // Layer Settings
            XmlNode layerSettingsNode = projectNode.SelectSingleNode("Layers");
            if (layerSettingsNode != null)
            {
                foreach (XmlNode childNode in layerSettingsNode.ChildNodes)
                {
                    LayerSettingsContent layerSettingsContent = LayerSettingsContentParser.Parse(childNode);
                    if (layerSettingsContent != null)
                    {
                        LayerSettings.Add(layerSettingsContent);
                    }
                }
            }
        }
    }
}
