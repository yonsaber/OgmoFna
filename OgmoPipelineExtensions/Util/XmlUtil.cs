using Microsoft.Xna.Framework;
using System.Globalization;
using System.Xml;

namespace OgmoPipelineExtensions
{
    public static class XmlUtil
    {
        /// <summary>
        /// Converts a node with X / Y data in it to a Vector2
        /// </summary>
        /// <param name="projectNode">Node to read from</param>
        /// <returns>A <see cref="Vector2"/> from an X Y Coord set</returns>
        public static Vector2 ReadXYToVec2(this XmlNode projectNode)
        {
            var ret = new Vector2();

            XmlNode node = projectNode.SelectSingleNode("X");
            if (node != null)
            {
                ret.X = int.Parse(node.InnerText, CultureInfo.InvariantCulture);
            }

            node = projectNode.SelectSingleNode("Y");
            if (node != null)
            {
                ret.Y = int.Parse(node.InnerText, CultureInfo.InvariantCulture);
            }

            return ret;
        }

        /// <summary>
        /// Converts a node with Width / Height data in it to a Vector2
        /// </summary>
        /// <param name="projectNode">Node to read from</param>
        /// <returns>A <see cref="Vector2"/> from an Width Height set</returns>
        public static Vector2 ReadWidthHeightToVec2(this XmlNode projectNode)
        {
            var ret = new Vector2();

            XmlNode node = projectNode.SelectSingleNode("Width");
            if (node != null)
            {
                ret.X = int.Parse(node.InnerText, CultureInfo.InvariantCulture);
            }

            node = projectNode.SelectSingleNode("Height");
            if (node != null)
            {
                ret.Y = int.Parse(node.InnerText, CultureInfo.InvariantCulture);
            }

            return ret;
        }

        public static Vector2 ReadXYToVec2(this XmlNode projectNode, string nodeName)
        {
            XmlNode node = projectNode.SelectSingleNode(nodeName);
            return node.ReadXYToVec2();
        }

        public static Vector2 ReadWidthHeightToVec2(this XmlNode projectNode, string nodeName)
        {
            XmlNode node = projectNode.SelectSingleNode(nodeName);
            return node.ReadWidthHeightToVec2();
        }

        // TODO: Generic parse

        public static int ReadAsInt(this XmlNode node, string attributeName, out int ret)
        {
            if (node.Attributes[attributeName] != null)
                ret = int.Parse(node.Attributes[attributeName].Value, CultureInfo.InvariantCulture);
            return ret = 0;
        }

        public static float ReadAsFloat(this XmlNode node, string attributeName, out float ret)
        {
            if (node.Attributes[attributeName] != null)
                ret = float.Parse(node.Attributes[attributeName].Value, CultureInfo.InvariantCulture);
            return ret = 0;
        }

        public static bool ReadAsBool(this XmlNode node, string attributeName, out bool ret)
        {
            if (node.Attributes[attributeName] != null)
            {
                ret = bool.Parse(node.Attributes[attributeName].Value);
                return ret;
            }

            return ret = false;
        }
    }
}
