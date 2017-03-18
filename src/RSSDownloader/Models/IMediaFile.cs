namespace RSSDownloader.Models
{
    public interface IMediaFile
    {
        string Url { get; }

        string OriginalFileName { get; }

        string FriendlyFileName { get; }

    }
}
