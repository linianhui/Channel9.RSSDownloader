using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Channel9.Models;
// ReSharper disable InconsistentNaming

namespace Channel9
{
    public class Channel9Client
    {
        private readonly HttpClient _httpClient = new HttpClient(new HttpClientHandler
        {
            AllowAutoRedirect = true
        });

        public async Task<RSS> GetRSSAsync(string rssUrl)
        {
            var rssStream = await _httpClient.GetStreamAsync(rssUrl);
            return RSS.Build(XElement.Load(rssStream));
        }
    }
}