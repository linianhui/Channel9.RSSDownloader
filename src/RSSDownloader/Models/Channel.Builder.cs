using System.Xml.Linq;
using RSSDownloader.Extensions;

namespace RSSDownloader.Models
{
    public partial class Channel
    {
        public static class Builder
        {
            public static readonly XName ElementName = XName.Get("channel");
            public static readonly XNamespace MediaNamespace = XNamespace.Get("http://search.yahoo.com/mrss/");

            private const string TitleName = "title";
            private const string LinkName = "link";

            public static Channel Build(XElement channelElement)
            {
                Throw.IfIsNull(channelElement, nameof(channelElement));
                Throw.IfElementNameIsNotMatch(channelElement, ElementName);
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