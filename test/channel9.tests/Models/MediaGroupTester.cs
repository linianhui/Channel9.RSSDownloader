using System;
using Channel9.Models;
using Channel9.Tests.Models.Base;
using Xunit;

namespace Channel9.Tests.Models
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