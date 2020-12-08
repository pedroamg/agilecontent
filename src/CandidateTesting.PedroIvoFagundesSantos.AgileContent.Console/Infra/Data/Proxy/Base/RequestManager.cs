using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Proxy.Base
{
    public class RequestManager
    {
        private readonly HttpClient _httpClient;
        public RequestManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string url, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(url, cancellationToken);
            IsValid(response);
            return await response.Content.ReadAsStringAsync();
        }

        private static void IsValid(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage.IsSuccessStatusCode || httpResponseMessage.StatusCode == HttpStatusCode.NotFound) 
                return;
            throw new HttpResponseException(httpResponseMessage);
        }
    }
}