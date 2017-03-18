using System;
using System.Xml.Linq;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Base;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class RssTester : ModelTestBase
    {
        [Fact]
        public void when_element_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => Rss.Builder.Build(null));
        }

        [Fact]
        public void when_element_is_not_rss()
        {
            Assert.Throws<ArgumentException>(() => Rss.Builder.Build(XElement.Parse("<i></i>")));
        }

        [Fact]
        public void when_rss_is_valid()
        {
            var rss = BuildRss();

            Assert.NotNull(rss);
        }
    }
}