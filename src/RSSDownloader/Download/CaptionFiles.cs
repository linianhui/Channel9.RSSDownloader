using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RSSDownloader.Models;

namespace RSSDownloader.Download
{
    public class CaptionFiles : Files
    {
        public CaptionFiles(Rss rss) : base(rss, "caption")
        {
        }

        public override List<FileUrl> FileUrls
        {
            get
            {
                return Rss.Channel.Lessons
                    .Where(lesson => lesson.Caption != null)
                    .Select(lesson => FileUrl.Build(lesson.Caption))
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
