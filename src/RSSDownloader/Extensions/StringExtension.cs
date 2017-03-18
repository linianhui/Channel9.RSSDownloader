namespace System
{
    internal static class StringExtension
    {
        public static string ToFileName(this string value)
        {
            return value?
                .Replace("/", "")
                .Replace("\\", "")
                .Replace(":", "")
                .Replace("*", "")
                .Replace("?", "")
                .Replace("\"", "")
                .Replace("？", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "")
                ?? string.Empty;
        }
    }
}