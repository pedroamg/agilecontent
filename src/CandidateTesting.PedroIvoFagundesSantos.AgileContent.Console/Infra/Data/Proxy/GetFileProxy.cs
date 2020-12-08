using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Proxy.Base;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Proxy.Interfaces;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Proxy
{
    public class GetFileProxy : RequestManager, IGetFileProxy
    {
        public GetFileProxy(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<string> GetFileAsync(string url, CancellationToken cancellationToken)
        {
            return  await GetAsync(url, cancellationToken);
        }
    }
}