using System;
using System.Collections.Generic;

namespace RSSDownloader.Models
{
    public partial class Channel
    {
        public Rss Rss { get; }

        private Channel(Rss rss)
        {
            Rss = rss;
        }

        public string Title { get; private set; }

        public string Link { get; private set; }

        public List<Lesson> Lessons { get; private set; }

        public string FileName => this.Title.ToFileName();
    }
}