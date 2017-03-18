using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace System.Xml.Linq
{
    public static class XElementExtension
    {
        public static string GetElementValue(this XElement xElement, XName name)
        {
            return xElement?.Element(name)?.Value?.Trim() ?? string.Empty;
        }
    }
}
