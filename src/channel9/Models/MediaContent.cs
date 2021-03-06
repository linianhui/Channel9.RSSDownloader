﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Channel9.Extensions;

namespace Channel9.Models
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

        #region Build

        public static readonly XName ElementName = XName.Get("content", RSS.MediaNamespace.NamespaceName);

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