using System.Xml.Linq;
using RSSDownloader.Extensions;

namespace RSSDownloader.Models
{
    public class Rss
    {
        private Rss(XElement rssElement)
        {
            Raw = rssElement;
        }

        public XElement Raw { get; }

        public Channel Channel { get; private set; }

        #region Build

        public static readonly XName ElementName = XName.Get("rss");

        public static readonly XNamespace MediaNamespace = XNamespace.Get("http://search.yahoo.com/mrss/");

        public static Rss Build(XElement rssElement)
        {
            Throw.IfIsNull(rssElement, nameof(rssElement));
            Throw.IfElementNameIsNotMatch(rssElement, ElementName);
            var rss = new Rss(rssElement);
            rss.Channel = Channel.Build(rss);
            return rss;
        }

        #endregion Build
    }
}