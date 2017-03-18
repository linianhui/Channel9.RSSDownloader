using System;
using System.Xml.Linq;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Base;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class EnclosureTester : ModelTestBase
    {
        [Fact]
        public void when_enclosure_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => Enclosure.Build(null));
        }

        [Fact]
        public void when_enclosure_is_valid()
        {
            var enclosure = BuildEnclosure();

            Assert.Equal("https://channel9.msdn.com/1.pptx", enclosure.Url);
        }
    }
}