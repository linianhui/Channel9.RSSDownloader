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
            public static readonly XName ElementName = XName.Get("content", Channel.Builder.MediaNamespace.NamespaceName);
            private const string UrlName = "url";
            private const string FileSizeName = "fileSize";

            public static MediaContent Build(XElement mediaContentElement)
            {
                Throw.IfIsNull(mediaContentElement, nameof(mediaContentElement));
                Throw.IfElementNameIsNotMatch(mediaContentElement, ElementName);
                return new MediaContent
                {
                    FileSize = mediaContentElement.GetAttributeValue<int>(FileSizeName),
                    Url = mediaContentElement.GetAttributeValue(UrlName),
                };
            }

            public static List<MediaContent> Build(IEnumerable<XElement> itemElements)
            {
                Throw.IfIsNull(itemElements, nameof(itemElements));
                return itemElements
                    .Select(Build)
                    .ToList();
            }
        }
    }
}