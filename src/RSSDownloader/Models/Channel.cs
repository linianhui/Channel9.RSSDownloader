using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RSSDownloader.Models
{
    public class Channel
    {
        private Channel()
        {
        }

        public string Title { get; private set; }

        public string Link { get; private set; }

        public List<ChannelItem> Items { get; private set; }

        public static class Builder
        {
            public static readonly XName ElementName = XName.Get("channel");
            private const string TitleName = "title";
            private const string LinkName = "link";

            public static Channel Build(XElement channelElement)
            {
                if (channelElement == null)
                {
                    throw new ArgumentNullException(nameof(channelElement));
                }
                if (ElementName != channelElement.Name)
                {
                    throw new ArgumentException($"{channelElement.Name.LocalName} is not {ElementName} element.");
                }
                return new Channel
                {
                    Title = channelElement.GetElementValue(TitleName),
                    Link = channelElement.GetElementValue(LinkName),
                    Items = ChannelItem.Builder.Build(channelElement.Elements(ChannelItem.Builder.ElementName))
                };
            }
        }
    }
}