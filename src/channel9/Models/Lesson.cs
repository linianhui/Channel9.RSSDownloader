using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Channel9.Extensions;

namespace Channel9.Models
{
    public class Lesson
    {
        public Channel Channel { get; }

        private Lesson(Channel channel)
        {
            Channel = channel;
        }

        public XElement Raw { get; private set; }

        public string Title { get; private set; }

        public string Link { get; private set; }

        public MediaGroup Media { get; private set; }

        public Enclosure Enclosure { get; private set; }

        public Caption Caption { get; private set; }

        #region Build

        public static readonly XName ElementName = XName.Get("item");

        private const string TitleName = "title";

        private const string LinkName = "link";

        private static Lesson BuildCore(Channel channel, XElement lessonElement)
        {
            Throw.IfIsNull(lessonElement, nameof(lessonElement));
            Throw.IfElementNameIsNotMatch(lessonElement, ElementName);
            var lesson = new Lesson(channel)
            {
                Raw = lessonElement,
                Title = lessonElement.GetElementValue(TitleName),
                Link = lessonElement.GetElementValue(LinkName)
            };
            lesson.Media = MediaGroup.Build(lesson);
            lesson.Enclosure = Enclosure.Build(lesson);
            lesson.Caption = new Caption(lesson);
            return lesson;
        }

        public static List<Lesson> Build(Channel channel)
        {
            Throw.IfIsNull(channel, nameof(channel));
            return channel.Raw.Elements(ElementName)
                .Select(lessonElement => BuildCore(channel, lessonElement))
                .ToList();
        }

        #endregion Build
    }
}