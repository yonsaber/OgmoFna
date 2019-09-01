using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace OgmoPipelineExtensions.ContentItems
{
    public class LevelContent
    {
        public ProjectContent Project;
        public ExternalReference<ProjectContent> ProjectReference;
        public int Height;
        public int Width;

        public LevelContent()
        {
        }

        public LevelContent(ProjectContent project, XmlDocument document)
        {
            Project = project;
            XmlNode levelNode = document["level"];
            Height = int.Parse(levelNode.Attributes["height"].Value, CultureInfo.InvariantCulture);
            Width = int.Parse(levelNode.Attributes["width"].Value, CultureInfo.InvariantCulture);
        }
    }
}
