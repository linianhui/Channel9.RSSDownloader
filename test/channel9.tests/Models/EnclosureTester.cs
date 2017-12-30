using System;
using Channel9.Models;
using Channel9.Tests.Models.Base;
using Xunit;

namespace Channel9.Tests.Models
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