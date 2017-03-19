namespace RSSDownloader.Models
{
    public class Caption
    {
        public Lesson Lesson { get; }

        public Caption(Lesson lesson)
        {
            Lesson = lesson;
        }

        public string Url => $"{Lesson.Link}/captions?f=webvtt&l=zh-cn";
    }
}
