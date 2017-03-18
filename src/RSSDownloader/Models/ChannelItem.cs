using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RSSDownloader.Models
{
    public class ChannelItem
    {
        private ChannelItem()
        {
        }

        public string Title { get; private set; }

        public string Link { get; private set; }

        public List<MediaContent> Medias { get; private set; }

        public static class Builder
        {
            public static readonly XName ElementName = XName.Get("item");
            private const string TitleName = "title";
            private const string LinkName = "link";

            public static ChannelItem Build(XElement itemElement)
            {
                if (itemElement == null)
                {
                    throw new ArgumentNullException(nameof(itemElement));
                }
                if (ElementName != itemElement.Name)
                {
                    throw new ArgumentException($"{itemElement.Name.LocalName} is not {ElementName} element.");
                }
                return new ChannelItem
                {
                    Title = itemElement.GetElementValue(TitleName),
                    Link = itemElement.GetElementValue(LinkName),
                    Medias = MediaContent.Builder.Build(itemElement.Descendants(MediaContent.Builder.ElementName))
                };
            }

            public static List<ChannelItem> Build(IEnumerable<XElement> itemElements)
            {
                if (itemElements == null)
                {
                    throw new ArgumentNullException(nameof(itemElements));
                }
                return itemElements
                    .Select(Build)
                    .ToList();
            }
        }
    }
}