using System;
using System.Net.Http;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.test.Base
{
    public class HttpClientFake : HttpClient
    {
        public HttpClientFake(object model)
        : base(new HttpMensagemHandlerFake(model))
        {
            BaseAddress = new Uri("http://www.testbase.com");
        }
    }
}