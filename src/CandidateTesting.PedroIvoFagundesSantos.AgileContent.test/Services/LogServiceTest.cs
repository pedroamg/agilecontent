using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Entities;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Services;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Services;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Proxy.Interfaces;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Repository;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.test.Base;
using FluentValidation;
using Moq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.test.Services
{
    public class LogServiceTest : IClassFixture<BaseFixture>
    {
        private readonly ILogService _logService;
        private Mock<IGetFileProxy> _getFileProxyMock;

        public LogServiceTest(BaseFixture baseFixture)
        {
            Mock();
            var log = new Log(baseFixture.SplitSeparators, new StringBuilder(), baseFixture.Positions);
            var repository = new LogRepository(log, _getFileProxyMock.Object);
            _logService = new LogService(repository);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("wrongurl@zyx")]
        [InlineData("http://urlmock.com")]
        public async Task Should_validate_if_url_is_valid(string input)
        {
            await Assert.ThrowsAsync<ValidationException>(() => _logService.GenerateAgoraLogAsync(input, CancellationToken.None));
        }

        [Fact]
        public async Task Should_return_true_if_log_was_created()
        {
            const string input = "http://urlmock.com ./outputpath/log";
            var result = await _logService.GenerateAgoraLogAsync(input, CancellationToken.None);
            Assert.True(result);
        }

        private void Mock()
        {

            _getFileProxyMock = new Mock<IGetFileProxy>();
            _getFileProxyMock.Setup(x => x.GetFileAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(
                (string url, CancellationToken cancellationToken) => "312|200|HIT|GET / robots.txt HTTP / 1.1|100.2");
        }
    }
}