using System.Xml.Linq;
using Channel9.Extensions;
// ReSharper disable InconsistentNaming

namespace Channel9.Models
{
    public class RSS
    {
        private RSS(XElement rssElement)
        {
            Raw = rssElement;
        }

        public XElement Raw { get; }

        public Channel Channel { get; private set; }

        #region Build

        public static readonly XName ElementName = XName.Get("rss");

        public static readonly XNamespace MediaNamespace = XNamespace.Get("http://search.yahoo.com/mrss/");

        public static RSS Build(XElement rssElement)
        {
            Throw.IfIsNull(rssElement, nameof(rssElement));
            Throw.IfElementNameIsNotMatch(rssElement, ElementName);
            var rss = new RSS(rssElement);
            rss.Channel = Channel.Build(rss);
            return rss;
        }

        #endregion Build
    }
}