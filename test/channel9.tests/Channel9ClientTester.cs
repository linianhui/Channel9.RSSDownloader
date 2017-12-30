using Xunit;

namespace Channel9.Tests
{
    public class Channel9ClientTester
    {
        [Fact]
        public void when_get_rss_form_web()
        {
            var rssClient = new Channel9Client ();
            var rss = rssClient.GetRSSAsync("https://channel9.msdn.com/blogs/dotnet/rss").Result;

            Assert.NotNull(rss);
            Assert.NotNull(rss.Channel);
            Assert.True(rss.Channel.Lessons.Count > 0);
        }
    }
}
