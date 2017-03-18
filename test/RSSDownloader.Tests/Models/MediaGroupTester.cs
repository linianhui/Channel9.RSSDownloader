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
        public void when_element_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => MediaGroup.Builder.Build(BuildLessons()[0], (XElement)null));
        }

        [Fact]
        public void when_element_is_not_item()
        {
            Assert.Throws<ArgumentException>(() => MediaGroup.Builder.Build(BuildLessons()[0], XElement.Parse("<i></i>")));
        }

        [Fact]
        public void when_media_group_is_valid()
        {
            var mediaGroup = BuildMediaGroup();

            Assert.NotNull(mediaGroup);
        }
    }
}