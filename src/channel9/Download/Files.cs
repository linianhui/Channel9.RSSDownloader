using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Channel9.Extensions;
using Channel9.Models;

namespace Channel9.Download
{
    public abstract class Files
    {
        public RSS Rss { get; }

        public string Type { get; }

        protected Files(RSS rss, string type)
        {
            Rss = rss;
            Type = type;
        }

        public string FileNamePrefix => $"{Rss.Channel.Title.ToFileName()}_{Type}";

        public abstract List<FileUrl> FileUrls { get; }

        public abstract void Save(string filePath);

        protected virtual void SaveDownloadLinkFile(string filePath)
        {
            var downloadFile = new StringBuilder();
            foreach (var file in FileUrls)
            {
                downloadFile.AppendLine(file.Url);
            }
            File.WriteAllText($"{filePath}//{FileNamePrefix}_download_link.txt", downloadFile.ToString());
        }

        protected virtual void SaveRenameFile(string filePath)
        {
            var renameFile = new StringBuilder();
            foreach (var file in FileUrls)
            {
                renameFile.AppendLine($"RENAME \"{file.OriginalFileName}\" \"{file.FriendlyFileName}\"");
            }
            File.WriteAllText($"{filePath}//{FileNamePrefix}_rename.bat", renameFile.ToString());
        }

        protected virtual void SavePowerShelllDownloadFile(string filePath)
        {
            var downloadFile = new StringBuilder();
            foreach (var file in FileUrls)
            {
                downloadFile.AppendLine($"Invoke-WebRequest \"{file.Url}\" -OutFile \"{file.FriendlyFileName}\"");
            }
            File.WriteAllText($"{filePath}//{FileNamePrefix}_download.ps1", downloadFile.ToString());
        }

        #region Build

        private static readonly IReadOnlyList<Type> SubTypes;

        static Files()
        {
            SubTypes = typeof(Files).GetTypeInfo()
                .Assembly
                .GetTypes()
                .Where(type => typeof(Files).IsAssignableFrom(type) && type != typeof(Files))
                .ToList();
        }

        public static List<Files> Build(RSS rss)
        {
            return SubTypes
                .Select(type => (Files)Activator.CreateInstance(type, rss))
                .ToList();
        }

        #endregion
    }
}
