using System;
using System.IO;
using System.Xml.Linq;
using RSSDownloader.Extensions;

namespace RSSDownloader.Models
{
    public class Enclosure : IMediaFile
    {
        public Lesson Lesson { get; }

        private Enclosure(Lesson lesson)
        {
            Lesson = lesson;
        }

        public XElement Raw { get; private set; }

        public string Url { get; private set; }

        public string OriginalFileName => Path.GetFileName(this.Url);

        public string FriendlyFileName => this.Lesson.Title.ToFileName() + Path.GetExtension(this.Url);

        #region Build

        public static readonly XName ElementName = XName.Get("enclosure");

        private const string UrlName = "url";

        private static Enclosure BuildCore(Lesson lesson, XElement enclosureElement)
        {
            Throw.IfIsNull(enclosureElement, nameof(enclosureElement));
            Throw.IfElementNameIsNotMatch(enclosureElement, ElementName);
            return new Enclosure(lesson)
            {
                Raw = enclosureElement,
                Url = enclosureElement.GetAttributeValue(UrlName),
            };
        }

        public static Enclosure Build(Lesson lesson)
        {
            Throw.IfIsNull(lesson, nameof(lesson));
            var enclosureElement = lesson.Raw.Element(ElementName);
            if (enclosureElement == null)
            {
                return null;
            }
            return BuildCore(lesson, enclosureElement);
        }

        #endregion Build
    }
}