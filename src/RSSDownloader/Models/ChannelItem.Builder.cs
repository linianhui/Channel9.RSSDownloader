using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using RSSDownloader.Extensions;

namespace RSSDownloader.Models
{
    public partial class ChannelItem
    {
        public static class Builder
        {
            public static readonly XName ElementName = XName.Get("item");
            private const string TitleName = "title";
            private const string LinkName = "link";

            public static ChannelItem Build(XElement channelItemElement)
            {
                Throw.IfIsNull(channelItemElement, nameof(channelItemElement));
                Throw.IfElementNameIsNotMatch(channelItemElement, ElementName);
                return new ChannelItem
                {
                    Title = channelItemElement.GetElementValue(TitleName),
                    Link = channelItemElement.GetElementValue(LinkName),
                    Media = MediaGroup.Builder.Build(channelItemElement.Element(MediaGroup.Builder.ElementName))
                };
            }

            public static List<ChannelItem> Build(IEnumerable<XElement> itemElements)
            {
                Throw.IfIsNull(itemElements, nameof(itemElements));
                return itemElements
                    .Select(Build)
                    .ToList();
            }
        }
    }
}