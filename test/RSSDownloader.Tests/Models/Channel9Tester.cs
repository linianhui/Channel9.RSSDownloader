using System;
using System.Xml.Linq;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Datas;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class ChannelTester : TestBase
    {
        [Fact]
        public void when_element_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => Channel.Builder.Build(null));
        }

        [Fact]
        public void when_element_is_not_channel()
        {
            Assert.Throws<ArgumentException>(() => Channel.Builder.Build(XElement.Parse("<i></i>")));
        }

        [Fact]
        public void when_channel_is_valid()
        {
            var channel = BuildChannel();

            Assert.NotNull(channel);
            Assert.Equal("Channel 9 title", channel.Title);
            Assert.Equal("https://channel9.msdn.com/", channel.Link);
        }
    }
}