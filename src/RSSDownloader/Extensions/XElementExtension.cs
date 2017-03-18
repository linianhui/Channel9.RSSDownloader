namespace System.Xml.Linq
{
    public static class XElementExtension
    {
        public static string GetElementValue(this XElement xElement, XName name)
        {
            return xElement?.Element(name)?.Value?.Trim() ?? string.Empty;
        }

        public static string GetAttributeValue(this XElement xElement, XName name)
        {
            return xElement?.Attribute(name)?.Value?.Trim() ?? string.Empty;
        }

        public static int GetAttributeValue<T>(this XElement xElement, XName name)
        {
            if (typeof(T) == typeof(int))
            {
                return int.Parse(GetAttributeValue(xElement, name));
            }
            throw new NotSupportedException();
        }
    }
}