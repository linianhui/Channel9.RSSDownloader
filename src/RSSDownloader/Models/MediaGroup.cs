using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using RSSDownloader.Extensions;

namespace RSSDownloader.Models
{
    public class MediaGroup
    {
        public Lesson Lesson { get; }

        private MediaGroup(Lesson lesson)
        {
            Lesson = lesson;
        }

        public XElement Raw { get; private set; }

        public List<MediaContent> Contents { get; private set; }

        public MediaContent Max => Contents.OrderByDescending(mediaContent => mediaContent.FileSize).First();

        #region Build

        public static readonly XName ElementName = XName.Get("group", Rss.MediaNamespace.NamespaceName);

        private static MediaGroup BuildCore(Lesson lesson, XElement mediaGroupElement)
        {
            Throw.IfIsNull(mediaGroupElement, nameof(mediaGroupElement));
            Throw.IfElementNameIsNotMatch(mediaGroupElement, ElementName);
            var mediaGroup = new MediaGroup(lesson)
            {
                Raw = mediaGroupElement,
            };
            mediaGroup.Contents = MediaContent.Build(mediaGroup);
            return mediaGroup;
        }

        public static MediaGroup Build(Lesson lesson)
        {
            Throw.IfIsNull(lesson, nameof(lesson));
            return BuildCore(lesson, lesson.Raw.Element(ElementName));
        }

        #endregion Build
    }
}