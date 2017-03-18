using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using RSSDownloader.Extensions;

namespace RSSDownloader.Models
{
    public partial class Lesson
    {
        public static class Builder
        {
            public static readonly XName ElementName = XName.Get("item");
            private const string TitleName = "title";
            private const string LinkName = "link";

            public static Lesson Build(Channel channel, XElement lessonElement)
            {
                Throw.IfIsNull(channel, nameof(channel));
                Throw.IfIsNull(lessonElement, nameof(lessonElement));
                Throw.IfElementNameIsNotMatch(lessonElement, ElementName);
                var lesson = new Lesson(channel)
                {
                    Title = lessonElement.GetElementValue(TitleName),
                    Link = lessonElement.GetElementValue(LinkName)
                };
                lesson.Media = MediaGroup.Builder.Build(lesson, lessonElement.Element(MediaGroup.Builder.ElementName));
                return lesson;
            }

            public static List<Lesson> Build(Channel channel, IEnumerable<XElement> lessonElements)
            {
                Throw.IfIsNull(lessonElements, nameof(lessonElements));
                return lessonElements
                    .Select(lessonElement => Build(channel, lessonElement))
                    .ToList();
            }
        }
    }
}