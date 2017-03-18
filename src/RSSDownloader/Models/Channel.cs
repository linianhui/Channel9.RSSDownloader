using System;
using System.Collections.Generic;
using System.Xml.Linq;
using RSSDownloader.Extensions;

namespace RSSDownloader.Models
{
    public class Channel
    {
        public Rss Rss { get; }

        private Channel(Rss rss)
        {
            Rss = rss;
        }

        public XElement Raw { get; private set; }

        public string Title { get; private set; }

        public string Link { get; private set; }

        public List<Lesson> Lessons { get; private set; }

        public string FileName => this.Title.ToFileName();

        #region Build

        public static readonly XName ElementName = XName.Get("channel");

        private const string TitleName = "title";

        private const string LinkName = "link";

        private static Channel BuildCore(Rss rss, XElement channelElement)
        {
            Throw.IfIsNull(channelElement, nameof(channelElement));
            Throw.IfElementNameIsNotMatch(channelElement, ElementName);
            var channel = new Channel(rss)
            {
                Raw = channelElement,
                Title = channelElement.GetElementValue(TitleName),
                Link = channelElement.GetElementValue(LinkName),
            };
            channel.Lessons = Lesson.Build(channel);
            return channel;
        }

        public static Channel Build(Rss rss)
        {
            Throw.IfIsNull(rss, nameof(rss));
            return BuildCore(rss, rss.Raw.Element(ElementName));
        }

        #endregion Build
    }
}