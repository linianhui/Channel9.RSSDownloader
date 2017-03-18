using System;
using System.Collections.Generic;
using System.Text;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Xml;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class ChannelTester
    {
        [Fact]
        public void when_element_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new Channel(null));
        }

        [Fact]
        public void when_element_is_not_channel()
        {
            Assert.Throws<ArgumentException>(() => new Channel(RssXml.Rss));
        }

        [Fact]
        public void when_channel_is_valid()
        {
            var channel = new Channel(RssXml.Rss.Element(Channel.ChannelName));

            Assert.Equal("dotnet - Channel 9", channel.Title);
            Assert.Equal("https://s.ch9.ms/Blogs/dotnet", channel.Link);
        }
    }
}
