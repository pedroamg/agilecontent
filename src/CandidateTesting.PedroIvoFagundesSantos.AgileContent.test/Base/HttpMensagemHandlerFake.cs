using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.test.Base
{
    public class HttpMensagemHandlerFake : HttpMessageHandler
    {
        private readonly object _model;

        public HttpMensagemHandlerFake(object model)
        {
            _model = model;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(_model))
            });
        }
    }
}