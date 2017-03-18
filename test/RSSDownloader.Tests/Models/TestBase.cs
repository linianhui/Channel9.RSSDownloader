using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Xml;

namespace RSSDownloader.Tests.Models
{
    public class TestBase
    {
        public Channel BuildChannel() => Channel.Builder.Build(RssXml.Rss.Element(Channel.Builder.ElementName));
    }
}