using RSSDownloader.Web;
using Xunit;

namespace RSSDownloader.Tests
{
    public class RssClientTester
    {
        [Fact]
        public void when_get_rss_form_web()
        {
            var rssClient = new RssClient();
            var rss = rssClient.GetAsync("https://channel9.msdn.com/blogs/dotnet/rss").Result;

            Assert.NotNull(rss);
            Assert.NotNull(rss.Channel);
            Assert.True(rss.Channel.Items.Count > 0);
        }
    }
}
