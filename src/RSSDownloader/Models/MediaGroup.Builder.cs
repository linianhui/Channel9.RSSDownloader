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

            public static MediaGroup Build(XElement mediaGroupElement)
            {
                Throw.IfIsNull(mediaGroupElement, nameof(mediaGroupElement));
                Throw.IfElementNameIsNotMatch(mediaGroupElement, ElementName);
                return new MediaGroup
                {
                    Contents = MediaContent.Builder.Build(mediaGroupElement.Elements())
                };
            }
        }
    }
}