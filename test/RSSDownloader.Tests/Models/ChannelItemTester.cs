using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using RSSDownloader.Models;
using RSSDownloader.Tests.Models.Xml;
using Xunit;

namespace RSSDownloader.Tests.Models
{
    public class ChannelItemTester : TestBase
    {
        [Fact]
        public void when_element_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => ChannelItem.Parser.Parse((XElement)null));
        }

        [Fact]
        public void when_element_is_not_item()
        {
            Assert.Throws<ArgumentException>(() => ChannelItem.Parser.Parse(RssXml.Rss));
        }

        [Fact]
        public void when_item_is_valid()
        {
            var channel = BuildChannel();

            Assert.Equal("Get started with VS Code using C# and .NET Core on Windows", channel.Items[0].Title);
            Assert.Equal("https://channel9.msdn.com/Blogs/dotnet/Get-started-VSCode-Csharp-NET-Core-Windows", channel.Items[0].Link);

            Assert.Equal("2", channel.Items[1].Title);
            Assert.Equal("https://channel9.msdn.com/2", channel.Items[1].Link);

        }
    }
}
