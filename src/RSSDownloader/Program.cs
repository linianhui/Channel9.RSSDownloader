using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RSSDownloader.Extensions;
using RSSDownloader.Web;
using System.Linq;
using RSSDownloader.Download;
using RSSDownloader.Models;

namespace RSSDownloader
{
    internal class Program
    {
        private static readonly RssClient RssClient = new RssClient();

        private static void Main(string[] channel9RssUrls)
        {
            Throw.IfIsNullOrEmpty(channel9RssUrls, nameof(channel9RssUrls));

            channel9RssUrls.ToList().ForEach(Download);

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

            Files.Build(rss).ForEach(file => file.Save(filePath));

            Log("[Save File] OK", ConsoleColor.Green);
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