namespace RSSDownloader.Models
{
    public partial class MediaContent
    {
        private MediaContent()
        {
        }

        public string Url { get; private set; }

        public int FileSize { get; private set; }
    }
}