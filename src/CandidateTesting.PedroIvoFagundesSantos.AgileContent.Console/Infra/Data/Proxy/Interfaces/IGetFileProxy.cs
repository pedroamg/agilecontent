using System.Threading;
using System.Threading.Tasks;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Proxy.Interfaces
{
    public interface IGetFileProxy
    {
        Task<string> GetFileAsync(string url, CancellationToken cancellationToken);
    }
}   