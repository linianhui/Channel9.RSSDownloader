using System;
using System.Xml.Linq;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Datas;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class ChannelItemTester : TestBase
    {
        [Fact]
        public void when_element_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => ChannelItem.Builder.Build((XElement)null));
        }

        [Fact]
        public void when_element_is_not_item()
        {
            Assert.Throws<ArgumentException>(() => ChannelItem.Builder.Build(StaticData.Rss));
        }

        [Fact]
        public void when_item_is_valid()
        {
            var channel = BuildChannel();

            Assert.Equal(2, channel.Items.Count);

            Assert.Equal("item title", channel.Items[0].Title);
            Assert.Equal("https://channel9.msdn.com/item-link", channel.Items[0].Link);

            Assert.Equal("item title 2", channel.Items[1].Title);
            Assert.Equal("https://channel9.msdn.com/item-link-2", channel.Items[1].Link);
        }
    }
}