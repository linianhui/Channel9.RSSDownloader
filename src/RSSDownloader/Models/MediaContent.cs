using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RSSDownloader.Models
{
    public class MediaContent
    {
        private MediaContent()
        {
        }

        public string Url { get; private set; }

        public int FileSize { get; private set; }

        public static class Builder
        {
            public static readonly XName ElementName = XName.Get("content", "http://search.yahoo.com/mrss/");
            private const string UrlName = "url";
            private const string FileSizeName = "fileSize";

            public static MediaContent Build(XElement itemElement)
            {
                if (itemElement == null)
                {
                    throw new ArgumentNullException(nameof(itemElement));
                }
                if (ElementName != itemElement.Name)
                {
                    throw new ArgumentException($"{itemElement.Name.LocalName} is not {ElementName} element.");
                }
                return new MediaContent
                {
                    FileSize = itemElement.GetAttributeValue<int>(FileSizeName),
                    Url = itemElement.GetAttributeValue(UrlName),
                };
            }

            public static List<MediaContent> Build(IEnumerable<XElement> itemElements)
            {
                if (itemElements == null)
                {
                    throw new ArgumentNullException(nameof(itemElements));
                }
                return itemElements
                    .Select(Build)
                    .ToList();
            }
        }
    }
}