using System;
using System.IO;
using System.Linq;
using Channel9.Download;
using Channel9.Extensions;

namespace Channel9
{
    internal class Program
    {
        private static readonly Channel9Client RssClient = new Channel9Client();

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

            var rss = RssClient.GetRSSAsync(channel9RssUrl).Result;

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