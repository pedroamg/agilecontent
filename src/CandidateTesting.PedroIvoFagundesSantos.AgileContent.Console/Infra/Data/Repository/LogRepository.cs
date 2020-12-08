using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Entities;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Repositories;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Proxy.Interfaces;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly Log _log;
        private readonly IGetFileProxy _getFileProxy;
        public LogRepository(Log log, IGetFileProxy getFileProxy)
        {
            _log = log;
            _getFileProxy = getFileProxy;
        }
        public async Task<string> GetLogInAgoraFormatAsync(string sourceUrl, CancellationToken cancellationToken)
        {
            var file = await _getFileProxy.GetFileAsync(sourceUrl, cancellationToken);
            return _log.GetAgoraLogFormat(file);
        }

        public async Task WriteLogToOutput(string targetPath, string agoraLogFile, CancellationToken cancellationToken)
        {
            if (!Directory.Exists(Path.GetDirectoryName(targetPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(targetPath));

            await File.WriteAllTextAsync(targetPath, agoraLogFile, cancellationToken);
        }
    }
}