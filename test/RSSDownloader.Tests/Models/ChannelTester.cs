using System;
using System.Collections.Generic;
using System.Text;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Xml;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class ChannelTester:TestBase
    {
        [Fact]
        public void when_element_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => Channel.Parser.Parse(null));
        }

        [Fact]
        public void when_element_is_not_channel()
        {
            Assert.Throws<ArgumentException>(() => Channel.Parser.Parse(RssXml.Rss));
        }

        [Fact]
        public void when_channel_is_valid()
        {
            var channel = BuildChannel();

            Assert.Equal("dotnet - Channel 9", channel.Title);
            Assert.Equal("https://s.ch9.ms/Blogs/dotnet", channel.Link);
        }
    }
}
