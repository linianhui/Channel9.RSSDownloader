using System.Collections.Generic;
using System.Linq;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Datas;

namespace RSSDownloader.Tests.Models.Base
{
    public class ModelTestBase
    {
        public Rss BuildRss() => Rss.Build(StaticData.Rss);

        public Channel BuildChannel() => BuildRss().Channel;

        public List<Lesson> BuildLessons() => BuildRss().Channel.Lessons;

        public MediaGroup BuildMediaGroup() => BuildRss().Channel.Lessons[0].Media;

        public List<MediaContent> BuildMediaContents() => BuildRss().Channel.Lessons[0].Media.Contents;
    }
}