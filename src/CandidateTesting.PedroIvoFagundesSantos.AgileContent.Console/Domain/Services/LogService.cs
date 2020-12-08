using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Repositories;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Services;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Validations;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
     
        public async Task<bool> GenerateAgoraLogAsync(string input, CancellationToken cancellationToken)
        {
            var url = await GetSourceUrl(input, cancellationToken);
            var agoraLogFile = await _logRepository.GetLogInAgoraFormatAsync(url, cancellationToken);

            var targetPath = await GeTargetPath(input, cancellationToken);
            await _logRepository.WriteLogToOutput(targetPath, agoraLogFile, cancellationToken);
            return true;
        }

        private static async Task<string> GetSourceUrl(string input, CancellationToken cancellationToken)
        {
            var sourceUrl = input?.Split(' ')[0];
            await new UrlValidation().ValidateAndThrowAsync(sourceUrl, cancellationToken);
            return sourceUrl;
        }

        private static async Task<string> GeTargetPath(string input, CancellationToken cancellationToken)
        {
            var targetPath = input?.Split(' ')[1];
            await new PathValidation().ValidateAndThrowAsync(targetPath, cancellationToken);
            return targetPath;
        }
    }
}