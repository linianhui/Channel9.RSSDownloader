using System.Collections.Generic;

namespace RSSDownloader.Models
{
    public partial class MediaGroup
    {
        private MediaGroup()
        {
        }

        public List<MediaContent> Contents { get; private set; }
    }
}