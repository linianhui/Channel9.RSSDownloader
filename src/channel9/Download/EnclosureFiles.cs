using System.Collections.Generic;
using System.Linq;
using Channel9.Models;

namespace Channel9.Download
{
    public class EnclosureFiles : Files
    {
        public EnclosureFiles(RSS rss) : base(rss, "enclosure")
        {
        }

        public override List<FileUrl> FileUrls
        {
            get
            {
                return Rss.Channel.Lessons
                    .Where(lesson => lesson.Enclosure != null)
                    .Select(lesson => FileUrl.Build(lesson.Enclosure))
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
