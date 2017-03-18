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
                return new Rss
                {
                    Channel = Channel.Builder.Build(rssElement.Element(Channel.Builder.ElementName))
                };
            }
        }
    }
}
