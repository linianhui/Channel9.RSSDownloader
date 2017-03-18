using System;
using System.IO;
using System.Text;
using RSSDownloader.Extensions;
using RSSDownloader.Web;
using System.Linq;

namespace RSSDownloader
{
    internal class Program
    {
        private static readonly RssClient RssClient = new RssClient();

        private static void Main(string[] channel9RssUrls)
        {
            Throw.IfIsNullOrEmpty(channel9RssUrls, nameof(channel9RssUrls));

            foreach (var channel9RssUrl in channel9RssUrls)
            {
                Download(channel9RssUrl);
            }

            Log("\r\nOK", ConsoleColor.Green);
        }

        private static void Download(string channel9RssUrl)
        {
            Log($"\r\n[Download] {channel9RssUrl}");
            var rss = RssClient.GetAsync(channel9RssUrl).Result;
            Log("[Download] OK", ConsoleColor.Green);
            var downloadFile = new StringBuilder();
            var renameFile = new StringBuilder();
            var mediaContents = rss.Channel.Lessons.Select(lesson => lesson.Media.Max).ToList();
            foreach (var mediaContent in mediaContents)
            {
                downloadFile.AppendLine(mediaContent.Url);
                renameFile.AppendLine($"RENAME \"{mediaContent.FileNameOfUrl}\" \"{mediaContent.FileNameOfLesson}\"");
            }
            var currentDirectory = Directory.GetCurrentDirectory();
            Directory.CreateDirectory("files");
            File.WriteAllText($"{currentDirectory}\\files\\{rss.Channel.FileName}_download.txt", downloadFile.ToString());
            File.WriteAllText($"{currentDirectory}\\files\\{rss.Channel.FileName}_rename.bat", renameFile.ToString());

            Log("[Save File] OK", ConsoleColor.Green);
        }

        private static void Log(string message, ConsoleColor? color = null)
        {
            var currentColor = Console.ForegroundColor;
            if (color != null)
            {
                Console.ForegroundColor = color.Value;
            }
            Console.WriteLine("message");
            Console.ForegroundColor = currentColor;
        }
    }
}