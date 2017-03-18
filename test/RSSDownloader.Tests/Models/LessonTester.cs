using System;
using System.Xml.Linq;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Base;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class LessonTester : ModelTestBase
    {
        [Fact]
        public void when_channel_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => Lesson.Build(null));
        }

        [Fact]
        public void when_lessons_is_valid()
        {
            var lessons = BuildLessons();

            Assert.Equal(2, lessons.Count);

            Assert.Equal("item title", lessons[0].Title);
            Assert.Equal("https://channel9.msdn.com/item-link", lessons[0].Link);

            Assert.Equal("item title 2", lessons[1].Title);
            Assert.Equal("https://channel9.msdn.com/item-link-2", lessons[1].Link);
        }
    }
}