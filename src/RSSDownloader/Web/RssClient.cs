using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using RSSDownloader.Models;

namespace RSSDownloader.Web
{
    public class RssClient
    {
        private readonly HttpClient _httpClient = new HttpClient(new HttpClientHandler
        {
            AllowAutoRedirect = true
        });

        public async Task<Rss> GetAsync(string rssUrl)
        {
            var rssStream = await _httpClient.GetStreamAsync(rssUrl);
            return Rss.Builder.Build(XElement.Load(rssStream));
        }
    }
}