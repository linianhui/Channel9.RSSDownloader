using System.Linq;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Datas;

namespace RSSDownloader.Tests.Models
{
    public class TestBase
    {
        public Channel BuildChannel() => Channel.Builder.Build(StaticData.Rss.Elements().First());
    }
}