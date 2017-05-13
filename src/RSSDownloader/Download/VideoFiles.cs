using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RSSDownloader.Models;

namespace RSSDownloader.Download
{
    public class VideoFiles : Files
    {
        public VideoFiles(Rss rss) : base(rss, "video")
        {
        }

        public override List<FileUrl> FileUrls
        {
            get
            {
                return Rss.Channel.Lessons
                    .Where(lesson => lesson.Media != null)
                    .Select(lesson => FileUrl.Build(lesson.Media.Max))
                    .Where(fileUrl => fileUrl != null)
                    .ToList();
            }
        }

        public override void Save(string filePath)
        {
            SaveDownloadLinkFile(filePath);
            SaveRenameFile(filePath);
            SavePowerShelllDownloadFile(filePath);
        }
    }
}
