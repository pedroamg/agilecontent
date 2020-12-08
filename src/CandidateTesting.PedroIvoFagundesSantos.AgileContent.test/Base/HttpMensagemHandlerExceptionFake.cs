using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.test.Base
{
    public class HttpMensagemHandlerExceptionFake : HttpMessageHandler
    {
        private readonly Exception _exception;

        public HttpMensagemHandlerExceptionFake(Exception exception)
        {
            _exception = exception;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            throw _exception;
        }
    }
}