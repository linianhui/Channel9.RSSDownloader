using System.Collections.Generic;
using System.Linq;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Datas;

namespace RSSDownloader.Tests.Models.Base
{
    public class ModelTestBase
    {
        public Rss BuildRss() => Rss.Builder.Build(StaticData.Rss);

        public Channel BuildChannel() => BuildRss().Channel;

        public List<ChannelItem> BuildChannelItems() => BuildRss().Channel.Items;

        public MediaGroup BuildMediaGroup() => BuildRss().Channel.Items[0].Media;

        public List<MediaContent> BuildMediaContents() => BuildRss().Channel.Items[0].Media.Contents;
    }
}