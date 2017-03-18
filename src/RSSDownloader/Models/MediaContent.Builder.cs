using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using RSSDownloader.Extensions;

namespace RSSDownloader.Models
{
    public partial class MediaContent
    {
        public static class Builder
        {
            public static readonly XName ElementName = XName.Get("content", Rss.Builder.MediaNamespace.NamespaceName);
            private const string UrlName = "url";
            private const string FileSizeName = "fileSize";

            public static MediaContent Build(MediaGroup mediaGroup, XElement mediaContentElement)
            {
                Throw.IfIsNull(mediaContentElement, nameof(mediaContentElement));
                Throw.IfElementNameIsNotMatch(mediaContentElement, ElementName);
                return new MediaContent(mediaGroup)
                {
                    FileSize = mediaContentElement.GetAttributeValue<int>(FileSizeName),
                    Url = mediaContentElement.GetAttributeValue(UrlName),
                };
            }

            public static List<MediaContent> Build(MediaGroup mediaGroup, IEnumerable<XElement> mediaContentElements)
            {
                Throw.IfIsNull(mediaContentElements, nameof(mediaContentElements));
                return mediaContentElements
                    .Select(mediaContentElement => Build(mediaGroup, mediaContentElement))
                    .ToList();
            }
        }
    }
}