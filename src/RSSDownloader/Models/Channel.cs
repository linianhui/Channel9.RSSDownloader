using System.Collections.Generic;

namespace RSSDownloader.Models
{
    public partial class Channel
    {
        private Channel()
        {
        }

        public string Title { get; private set; }

        public string Link { get; private set; }

        public List<ChannelItem> Items { get; private set; }
    }
}