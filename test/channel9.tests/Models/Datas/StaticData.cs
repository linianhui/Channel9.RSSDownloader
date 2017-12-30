using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace Channel9.Tests.Models.Datas
{
    public static class StaticData
    {
        public static XElement Rss = XElement.Load(GetXmlFile());

        private static Stream GetXmlFile()
        {
            var currentType = typeof(StaticData).GetTypeInfo();
            return currentType.Assembly.GetManifestResourceStream(currentType.Namespace + ".rss.xml");
        }
    }
}