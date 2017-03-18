using System.Collections.Generic;
using System.Linq;

namespace RSSDownloader.Models
{
    public partial class MediaGroup
    {
        public Lesson Lesson { get; }

        private MediaGroup(Lesson lesson)
        {
            Lesson = lesson;
        }

        public List<MediaContent> Contents { get; private set; }

        public MediaContent Max => Contents.OrderByDescending(mediaContent => mediaContent.FileSize).First();
    }
}