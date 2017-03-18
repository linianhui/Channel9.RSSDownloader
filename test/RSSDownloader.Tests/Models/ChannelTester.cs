using System;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Base;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class ChannelTester : ModelTestBase
    {
        [Fact]
        public void when_rss_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => Channel.Build(null));
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