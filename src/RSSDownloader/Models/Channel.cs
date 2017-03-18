using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace RSSDownloader.Models
{
    public class Channel
    {
        public const string ChannelName = "channel";
        public const string TitleName = "title";
        public const string LinkName = "link";

        private readonly XElement _channelElement;

        public Channel(XElement channelXElement)
        {
            if (channelXElement == null)
            {
                throw new ArgumentNullException(nameof(channelXElement));
            }
            if (string.Equals(ChannelName, channelXElement.Name.LocalName, StringComparison.OrdinalIgnoreCase) == false)
            {
                throw new ArgumentException($"{channelXElement.Name.LocalName} is not {ChannelName} element.");
            }
            _channelElement = channelXElement;
        }

        public string Title => _channelElement.GetElementValue(TitleName);

        public string Link => _channelElement.GetElementValue(LinkName);
    }
}
