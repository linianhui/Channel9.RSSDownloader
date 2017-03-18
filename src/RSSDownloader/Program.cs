using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RSSDownloader.Extensions;
using RSSDownloader.Web;
using System.Linq;
using RSSDownloader.Models;

namespace RSSDownloader
{
    internal class Program
    {
        private static readonly RssClient RssClient = new RssClient();

        private static void Main(string[] channel9RssUrls)
        {
            channel9RssUrls = new string[]
            {
                "https://s.ch9.ms/Events/Build/2013/rss/"
            };
            Throw.IfIsNullOrEmpty(channel9RssUrls, nameof(channel9RssUrls));

            foreach (var channel9RssUrl in channel9RssUrls)
            {
                Download(channel9RssUrl);
            }

            Log("\r\nEnd", ConsoleColor.Green);
        }

        private static void Download(string channel9RssUrl)
        {
            if (channel9RssUrl.EndsWith("/slides") == false)
            {
                channel9RssUrl += "/slides";
            }

            Log($"\r\n[Download] {channel9RssUrl}");

            var rss = RssClient.GetAsync(channel9RssUrl).Result;

            Log("[Download] OK", ConsoleColor.Green);

            var filePath = $"{Directory.GetCurrentDirectory()}\\files";
            if (Directory.Exists(filePath) == false)
            {
                Directory.CreateDirectory(filePath);
            }
            filePath = filePath + "\\" + rss.Channel.FileName;

            CreateVideoDownloadFile(rss, filePath);

            CreateEnclosureDownloadFile(rss, filePath);

            Log("[Save File] OK", ConsoleColor.Green);
        }

        private static void CreateVideoDownloadFile(Rss rss, string filePath)
        {
            var mediaContents = rss.Channel.Lessons
                .Select(lesson => lesson.Media.Max)
                .ToList();
            CreateDownloadFileCore(filePath, "video", mediaContents);
        }

        private static void CreateEnclosureDownloadFile(Rss rss, string filePath)
        {
            var enclosures = rss.Channel.Lessons
                .Where(lesson => lesson.Enclosure != null)
                .Select(lesson => lesson.Enclosure)
                .ToList();
            CreateDownloadFileCore(filePath, "enclosure", enclosures);
        }

        private static void CreateDownloadFileCore(string filePath, string type, IEnumerable<IMediaFile> files)
        {
            var downloadFile = new StringBuilder();
            var renameFile = new StringBuilder();
            foreach (var file in files)
            {
                downloadFile.AppendLine(file.Url);
                renameFile.AppendLine($"RENAME \"{file.OriginalFileName}\" \"{file.FriendlyFileName}\"");
            }
            File.WriteAllText($"{filePath}_{type}_download.txt", downloadFile.ToString());
            File.WriteAllText($"{filePath}_{type}_rename.bat", renameFile.ToString());
        }

        private static void Log(string message, ConsoleColor? color = null)
        {
            var currentColor = Console.ForegroundColor;
            if (color != null)
            {
                Console.ForegroundColor = color.Value;
            }
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }
    }
}