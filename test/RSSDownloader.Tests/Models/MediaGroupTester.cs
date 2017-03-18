using System;
using System.Xml.Linq;
using RSSDownloader.Models;
using Xunit;
using RSSDownloader.Tests.Models.Base;

namespace RSSDownloader.Tests.Models
{
    public class MediaGroupTester : ModelTestBase
    {
        [Fact]
        public void when_lesson_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => MediaGroup.Build(null));
        }

        [Fact]
        public void when_media_group_is_valid()
        {
            var mediaGroup = BuildMediaGroup();

            Assert.NotNull(mediaGroup);
        }
    }
}