using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using RSSDownloader.Models;

namespace RSSDownloader.Web
{
    public class RssClient
    {
        public async Task<Rss> GetAsync(string rssUrl)
        {
            var httpClient = new HttpClient();
            var rssStream = await httpClient.GetStreamAsync(rssUrl);
            return Rss.Builder.Build(XElement.Load(rssStream));
        }
    }
}