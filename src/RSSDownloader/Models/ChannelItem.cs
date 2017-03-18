using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace RSSDownloader.Models
{
    public class ChannelItem
    {
        private ChannelItem() { }

        public string Title { get; private set; }

        public string Link { get; private set; }

        public static class Parser
        {
            public const string ElementName = "item";
            private const string TitleName = "title";
            private const string LinkName = "link";

            public static ChannelItem Parse(XElement itemElement)
            {
                if (itemElement == null)
                {
                    throw new ArgumentNullException(nameof(itemElement));
                }
                if (string.Equals(ElementName, itemElement.Name.LocalName, StringComparison.OrdinalIgnoreCase) == false)
                {
                    throw new ArgumentException($"{itemElement.Name.LocalName} is not {ElementName} element.");
                }
                return new ChannelItem
                {
                    Title = itemElement.GetElementValue(TitleName),
                    Link = itemElement.GetElementValue(LinkName)
                };
            }

            public static List<ChannelItem> Parse(IEnumerable<XElement> itemElements)
            {
                if (itemElements == null)
                {
                    throw new ArgumentNullException(nameof(itemElements));
                }
                return itemElements
                    .Select(Parse)
                    .ToList();
            }
        }
    }
}
