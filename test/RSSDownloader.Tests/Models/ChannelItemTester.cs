using System;
using System.Xml.Linq;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Base;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class ChannelItemTester : ModelTestBase
    {
        [Fact]
        public void when_element_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => ChannelItem.Builder.Build((XElement)null));
        }

        [Fact]
        public void when_element_is_not_item()
        {
            Assert.Throws<ArgumentException>(() => ChannelItem.Builder.Build(XElement.Parse("<i></i>")));
        }

        [Fact]
        public void when_channel_items_is_valid()
        {
            var channelItems = BuildChannelItems();

            Assert.Equal(2, channelItems.Count);

            Assert.Equal("item title", channelItems[0].Title);
            Assert.Equal("https://channel9.msdn.com/item-link", channelItems[0].Link);

            Assert.Equal("item title 2", channelItems[1].Title);
            Assert.Equal("https://channel9.msdn.com/item-link-2", channelItems[1].Link);
        }
    }
}