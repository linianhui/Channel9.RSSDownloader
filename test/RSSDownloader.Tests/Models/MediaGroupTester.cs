using System;
using System.Xml.Linq;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Datas;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class MediaGroupTester : TestBase
    {
        [Fact]
        public void when_element_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => MediaContent.Builder.Build((XElement)null));
        }

        [Fact]
        public void when_element_is_not_item()
        {
            Assert.Throws<ArgumentException>(() => MediaContent.Builder.Build(StaticData.Rss));
        }

        [Fact]
        public void when_content_is_valid()
        {
            var channel = BuildChannel();

            Assert.NotNull(channel.Items[0].Media);
        }
    }
}