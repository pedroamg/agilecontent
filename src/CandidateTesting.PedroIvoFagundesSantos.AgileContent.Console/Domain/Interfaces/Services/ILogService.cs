using System.Threading;
using System.Threading.Tasks;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Services
{
    public interface ILogService
    {
        public Task<bool> GenerateAgoraLogAsync(string input, CancellationToken cancellationToken);
    }
}