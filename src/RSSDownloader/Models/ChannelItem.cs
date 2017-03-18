using System.Collections.Generic;

namespace RSSDownloader.Models
{
    public partial class ChannelItem
    {
        private ChannelItem()
        {
        }

        public string Title { get; private set; }

        public string Link { get; private set; }

        public MediaGroup Media { get; private set; }
    }
}