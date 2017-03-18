using System;
using System.IO;

namespace RSSDownloader.Models
{
    public partial class MediaContent
    {
        public MediaGroup Group { get; }

        private MediaContent(MediaGroup mediaGroup)
        {
            Group = mediaGroup;
        }

        public string Url { get; private set; }

        public int FileSize { get; private set; }

        public string FileNameOfUrl => Path.GetFileName(this.Url);

        public string FileNameOfLesson => this.Group.Lesson.Title.ToFileName() + Path.GetExtension(this.Url);
    }
}