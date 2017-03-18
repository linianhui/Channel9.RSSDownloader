using System;
using System.Xml.Linq;

namespace RSSDownloader.Extensions
{
    internal class Throw
    {
        public static void IfIsNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void IfElementNameIsNotMatch(XElement element, XName elementName)
        {
            if (elementName != element.Name)
            {
                throw new ArgumentException($"[{element.Name}] is not [{elementName}] element.");
            }
        }
    }
}