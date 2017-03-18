using System;
using System.Xml.Linq;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Xml;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class MediaContentTester : TestBase
    {
        [Fact]
        public void when_element_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => MediaContent.Builder.Build((XElement)null));
        }

        [Fact]
        public void when_element_is_not_item()
        {
            Assert.Throws<ArgumentException>(() => MediaContent.Builder.Build(RssXml.Rss));
        }

        [Fact]
        public void when_content_is_valid()
        {
            var channel = BuildChannel();

            Assert.Equal("http://https://channel9.msdn.com/1.mp4", channel.Items[0].Medias[0].Url);
            Assert.Equal(1234567, channel.Items[0].Medias[0].FileSize);

            Assert.Equal("http://https://channel9.msdn.com/2.mp3", channel.Items[0].Medias[1].Url);
            Assert.Equal(12345, channel.Items[0].Medias[1].FileSize);
        }
    }
}