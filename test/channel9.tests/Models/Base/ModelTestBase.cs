using System.Collections.Generic;
using Channel9.Models;
using Channel9.Tests.Models.Datas;
// ReSharper disable InconsistentNaming

namespace Channel9.Tests.Models.Base
{
    public class ModelTestBase
    {
        public RSS BuildRSS() => RSS.Build(StaticData.Rss);

        public Channel BuildChannel() => BuildRSS().Channel;

        public List<Lesson> BuildLessons() => BuildRSS().Channel.Lessons;

        public MediaGroup BuildMediaGroup() => BuildRSS().Channel.Lessons[0].Media;

        public Enclosure BuildEnclosure() => BuildRSS().Channel.Lessons[0].Enclosure;

        public Caption BuildCaption() => BuildRSS().Channel.Lessons[0].Caption;

        public List<MediaContent> BuildMediaContents() => BuildRSS().Channel.Lessons[0].Media.Contents;
    }
}