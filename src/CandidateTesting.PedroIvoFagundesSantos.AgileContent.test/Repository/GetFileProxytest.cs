using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Entities;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Repositories;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Proxy;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Repository;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.test.Base;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.test.Repository
{
    public class GetFileProxytest : IClassFixture<BaseFixture>
    {
        private readonly ILogRepository _logRepository;
        public GetFileProxytest(BaseFixture baseFixture)
        {
            
            var httpClienteFileProxy = HttpClienteGetFileMock();
            var getFileProxy = new GetFileProxy(httpClienteFileProxy);
            var log = new Log(baseFixture.SplitSeparators, baseFixture.AgoraLogBuilder, baseFixture.Positions);
            _logRepository = new LogRepository(log, getFileProxy);
        }


        [Fact]
        public async Task Should_return_the_file_downloaded()
        {
            var agoraLogFile = await _logRepository.GetLogInAgoraFormatAsync("", CancellationToken.None);
            Assert.NotNull(agoraLogFile);
            Assert.Contains("GET 404 /not-found 143 199 MISS ", agoraLogFile);
        }

        private static HttpClientFake HttpClienteGetFileMock()
        {
            const string file = @"#Version 1.0 
                        #Date: 07/12/2020 20:47:37 
                        #Fields: provider http-method status-code uri-path time-taken response-size cache-status
                        ""MINHA CDN"" GET 200 /robots.txt 100 312 HIT 
                        ""MINHA CDN"" POST 200 /myImages 319 101 MISS 
                        ""MINHA CDN"" GET 404 /not-found 143 199 MISS 
                        ""MINHA CDN"" GET 200 /robots.txt 245 312 INVALIDATE";
            return new HttpClientFake(file);
        }
    }
}