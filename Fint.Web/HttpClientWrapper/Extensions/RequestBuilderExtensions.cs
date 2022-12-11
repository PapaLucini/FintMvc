using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientWrapper.Extensions
{
    public static class RequestBuilderExtensions
    {
        public static HttpRequestHeaders AddRequestBearerAuthenticationHeader(this HttpRequestHeaders httpRequest, string token)
        {
            httpRequest.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return httpRequest;
        }
    }
}
