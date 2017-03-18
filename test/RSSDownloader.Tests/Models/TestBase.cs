using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Xml;

namespace RSSDownloader.Tests.Models
{
    public class TestBase
    {
        public Channel BuildChannel() => Channel.Parser.Parse(RssXml.Rss.Element(Channel.Parser.ElementName));
    }
}