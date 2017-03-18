using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using RSSDownloader.Extensions;

namespace RSSDownloader.Models
{
    public class MediaContent
    {
        public MediaGroup Group { get; }

        private MediaContent(MediaGroup mediaGroup)
        {
            Group = mediaGroup;
        }

        public XElement Raw { get; private set; }

        public string Url { get; private set; }

        public int FileSize { get; private set; }

        public string FileNameOfUrl => Path.GetFileName(this.Url);

        public string FileNameOfLesson => this.Group.Lesson.Title.ToFileName() + Path.GetExtension(this.Url);

        #region Build

        public static readonly XName ElementName = XName.Get("content", Rss.MediaNamespace.NamespaceName);

        private const string UrlName = "url";

        private const string FileSizeName = "fileSize";

        private static MediaContent BuildCore(MediaGroup mediaGroup, XElement mediaContentElement)
        {
            Throw.IfIsNull(mediaContentElement, nameof(mediaContentElement));
            Throw.IfElementNameIsNotMatch(mediaContentElement, ElementName);
            return new MediaContent(mediaGroup)
            {
                Raw = mediaContentElement,
                FileSize = mediaContentElement.GetAttributeValue<int>(FileSizeName),
                Url = mediaContentElement.GetAttributeValue(UrlName),
            };
        }

        public static List<MediaContent> Build(MediaGroup mediaGroup)
        {
            Throw.IfIsNull(mediaGroup, nameof(mediaGroup));
            return mediaGroup.Raw.Elements()
                .Select(mediaContentElement => BuildCore(mediaGroup, mediaContentElement))
                .ToList();
        }

        #endregion Build
    }
}