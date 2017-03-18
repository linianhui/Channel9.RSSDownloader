using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using RSSDownloader.Extensions;

namespace RSSDownloader.Models
{
    public partial class Rss
    {
        public static class Builder
        {
            public static readonly XName ElementName = XName.Get("rss");
            public static readonly XNamespace MediaNamespace = XNamespace.Get("http://search.yahoo.com/mrss/");

            public static Rss Build(XElement rssElement)
            {
                Throw.IfIsNull(rssElement, nameof(rssElement));
                Throw.IfElementNameIsNotMatch(rssElement, ElementName);
                var rss = new Rss();
                rss.Channel = Channel.Builder.Build(rss, rssElement.Element(Channel.Builder.ElementName));
                return rss;
            }
        }
    }
}
