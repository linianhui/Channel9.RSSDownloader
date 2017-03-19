using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RSSDownloader.Models;

namespace RSSDownloader.Download
{
    public class EnclosureFiles : Files
    {
        public EnclosureFiles(Rss rss) : base(rss, "enclosure")
        {
        }

        public override List<FileUrl> FileUrls
        {
            get
            {
                return Rss.Channel.Lessons
                    .Where(lesson => lesson.Enclosure != null)
                    .Select(lesson => FileUrl.Build(lesson.Enclosure))
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
