using System.Collections.Generic;
using System.Linq;
using Channel9.Models;

namespace Channel9.Download
{
    public class CaptionFiles : Files
    {
        public CaptionFiles(RSS rss) : base(rss, "caption")
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
