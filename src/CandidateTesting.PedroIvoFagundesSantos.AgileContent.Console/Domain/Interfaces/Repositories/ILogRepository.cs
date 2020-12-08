using System.Threading;
using System.Threading.Tasks;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Repositories
{
    public interface ILogRepository
    {
        Task<string> GetLogInAgoraFormatAsync(string sourceUrl, CancellationToken cancellationToken);
        Task WriteLogToOutput(string targetPath, string agoraLogFile, CancellationToken cancellationToken);
    }
}