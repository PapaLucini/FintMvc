using HttpClientWrapper.Extensions;
using HttpClientWrapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientWrapper
{
    public class HttpClientService : IHttpClientService
    {
        private readonly System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
        public HttpClientService()
        {

        }

        public T SendRequest<T>(IRequestBuilder request)
        {
            return Task.Run(async () => await httpClient.SendHttpClientRequestAsync<T>(request)).Result;
        }
    }
}
