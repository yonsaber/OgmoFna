using System.Xml;
using System.Globalization;

namespace OgmoPipelineExtension.ContentItems
{
    public class ProjectSettingsContent
    {
        public int Height;
        public int MaxHeight;
        public int MaxWidth;
        public int MinHeight;
        public int MinWidth;
        public int Width;
        public string WorkingDirectory;

        public ProjectSettingsContent()
        {
            Height = 480;
            Width = 640;
            WorkingDirectory = "gfx";
        }

        public ProjectSettingsContent(XmlNode node)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                switch (childNode.Name)
                {
                    case "defaultHeight":
                        Height = int.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "maxHeight":
                        MaxHeight = int.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "maxWidth":
                        MaxWidth = int.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "minHeight":
                        MinHeight = int.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "minWidth":
                        MinWidth = int.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "defaultWidth":
                        Width = int.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "workingDirectory":
                        WorkingDirectory = childNode.InnerText;
                        break;
                }
            }
        }
    }
}
