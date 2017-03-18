using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using RSSDownloader.Extensions;

namespace RSSDownloader.Models
{
    public partial class MediaGroup
    {
        public static class Builder
        {
            public static readonly XName ElementName = XName.Get("group", Rss.Builder.MediaNamespace.NamespaceName);

            public static MediaGroup Build(Lesson lesson, XElement mediaGroupElement)
            {
                Throw.IfIsNull(lesson, nameof(lesson));
                Throw.IfIsNull(mediaGroupElement, nameof(mediaGroupElement));
                Throw.IfElementNameIsNotMatch(mediaGroupElement, ElementName);
                var mediaGroup = new MediaGroup(lesson);
                mediaGroup.Contents = MediaContent.Builder.Build(mediaGroup, mediaGroupElement.Elements());
                return mediaGroup;
            }
        }
    }
}