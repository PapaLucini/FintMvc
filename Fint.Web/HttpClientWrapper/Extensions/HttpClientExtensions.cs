using HttpClientWrapper.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientWrapper.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> SendHttpClientRequestAsync<T>(this System.Net.Http.HttpClient httpClient, IRequestBuilder request)
        {
            try
            {
                var httpRequestMessage = request.Build();
                var responseMessage = await httpClient.SendAsync(httpRequestMessage);
                var result = responseMessage.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
