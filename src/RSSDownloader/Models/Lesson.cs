namespace RSSDownloader.Models
{
    public partial class Lesson
    {
        public Channel Channel { get; }

        private Lesson(Channel channel)
        {
            Channel = channel;
        }

        public string Title { get; private set; }

        public string Link { get; private set; }

        public MediaGroup Media { get; private set; }

    }
}