using RSSDownloader.Tests.Models.Base;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class CaptionTester : ModelTestBase
    {

        [Fact]
        public void when_get_caption()
        {
            var caption = BuildCaption();
            Assert.Equal("https://channel9.msdn.com/item-link/captions?f=webvtt&l=zh-cn", caption.Url);
        }
    }
}