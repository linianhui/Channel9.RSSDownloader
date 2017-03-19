using System;
using System.IO;

namespace RSSDownloader.Models
{
    public class Caption : IMediaFile
    {
        public Lesson Lesson { get; }

        public Caption(Lesson lesson)
        {
            Lesson = lesson;
        }

        public string Url => $"{Lesson.Link}/captions?f=webvtt&l=zh-cn";

        public string OriginalFileName => Path.GetFileName(Lesson.Link) + ".vtt";

        public string FriendlyFileName => this.Lesson.Title.ToFileName() + ".vtt";
    }
}
