using System.IO;
using Channel9.Extensions;
using Channel9.Models;

namespace Channel9.Download
{
    public class FileUrl
    {
        private FileUrl()
        {

        }

        public string Url { get; private set; }

        public string OriginalFileName { get; private set; }

        public string FriendlyFileName { get; private set; }

        public static FileUrl Build(MediaContent mediaContent)
        {
            return new FileUrl
            {
                Url = mediaContent.Url,
                OriginalFileName = Path.GetFileName(mediaContent.Url),
                FriendlyFileName = mediaContent.Group.Lesson.Title.ToFileName() + Path.GetExtension(mediaContent.Url),
            };

        }

        public static FileUrl Build(Enclosure enclosure)
        {
            return new FileUrl
            {
                Url = enclosure.Url,
                OriginalFileName = Path.GetFileName(enclosure.Url),
                FriendlyFileName = enclosure.Lesson.Title.ToFileName() + Path.GetExtension(enclosure.Url),
            };
        }

        public static FileUrl Build(Caption caption)
        {
            return new FileUrl
            {
                Url = caption.Url,
                OriginalFileName = Path.GetFileName(caption.Lesson.Link) + ".vtt",
                FriendlyFileName = caption.Lesson.Title.ToFileName() + ".vtt",
            };
        }
    }
}
