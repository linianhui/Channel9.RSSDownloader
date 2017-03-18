using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace RSSDownloader.Models
{
    public class Channel
    {
        private Channel() { }

        public string Title { get; private set; }

        public string Link { get; private set; }

        public List<ChannelItem> Items { get; private set; }

        public static class Parser
        {
            public const string ElementName = "channel";
            private const string TitleName = "title";
            private const string LinkName = "link";

            public static Channel Parse(XElement channelElement)
            {
                if (channelElement == null)
                {
                    throw new ArgumentNullException(nameof(channelElement));
                }
                if (string.Equals(ElementName, channelElement.Name.LocalName, StringComparison.OrdinalIgnoreCase) == false)
                {
                    throw new ArgumentException($"{channelElement.Name.LocalName} is not {ElementName} element.");
                }
                return new Channel
                {
                    Title = channelElement.GetElementValue(TitleName),
                    Link = channelElement.GetElementValue(LinkName),
                    Items = ChannelItem.Parser.Parse(channelElement.Elements(ChannelItem.Parser.ElementName))
                };
            }
        }
    }
}
