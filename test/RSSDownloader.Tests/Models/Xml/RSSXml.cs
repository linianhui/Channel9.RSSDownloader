using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace RSSDownloader.Tests.Models.Xml
{
    public static class RssXml
    {
        public static XElement Rss = XElement.Load(GetXmlFile());

        private static Stream GetXmlFile()
        {
            var currentType = typeof(RssXml).GetTypeInfo();
            return currentType.Assembly.GetManifestResourceStream(currentType.Namespace + ".rss.xml");
        }
    }
}
