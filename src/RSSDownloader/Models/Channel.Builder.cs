using System.Xml.Linq;
using RSSDownloader.Extensions;

namespace RSSDownloader.Models
{
    public partial class Channel
    {
        public static class Builder
        {
            public static readonly XName ElementName = XName.Get("channel");

            private const string TitleName = "title";
            private const string LinkName = "link";

            public static Channel Build(Rss rss, XElement channelElement)
            {
                Throw.IfIsNull(rss, nameof(rss));
                Throw.IfIsNull(channelElement, nameof(channelElement));
                Throw.IfElementNameIsNotMatch(channelElement, ElementName);
                var channel = new Channel(rss)
                {
                    Title = channelElement.GetElementValue(TitleName),
                    Link = channelElement.GetElementValue(LinkName),
                };
                channel.Lessons = Lesson.Builder.Build(channel, channelElement.Elements(Lesson.Builder.ElementName));
                return channel;
            }
        }
    }
}