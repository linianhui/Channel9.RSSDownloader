using System;
using System.Xml.Linq;
using Channel9.Models;
using Channel9.Tests.Models.Base;
using Xunit;
// ReSharper disable InconsistentNaming

namespace Channel9.Tests.Models
{
    public class RSSTester : ModelTestBase
    {
        [Fact]
        public void when_element_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => RSS.Build(null));
        }

        [Fact]
        public void when_element_is_not_rss()
        {
            Assert.Throws<ArgumentException>(() => RSS.Build(XElement.Parse("<i></i>")));
        }

        [Fact]
        public void when_rss_is_valid()
        {
            var rss = BuildRSS();

            Assert.NotNull(rss);
        }
    }
}