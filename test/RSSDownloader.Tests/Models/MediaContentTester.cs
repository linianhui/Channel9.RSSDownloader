using System;
using System.Xml.Linq;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Base;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class MediaContentTester : ModelTestBase
    {
        [Fact]
        public void when_element_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => MediaContent.Builder.Build((XElement)null));
        }

        [Fact]
        public void when_element_is_not_item()
        {
            Assert.Throws<ArgumentException>(() => MediaContent.Builder.Build(XElement.Parse("<i></i>")));
        }

        [Fact]
        public void when_media_contents_is_valid()
        {
            var mediaContents = BuildMediaContents();

            Assert.Equal(2, mediaContents.Count);

            Assert.Equal("http://https://channel9.msdn.com/1.mp4", mediaContents[0].Url);
            Assert.Equal(1234567, mediaContents[0].FileSize);

            Assert.Equal("http://https://channel9.msdn.com/2.mp3", mediaContents[1].Url);
            Assert.Equal(12345, mediaContents[1].FileSize);
        }
    }
}