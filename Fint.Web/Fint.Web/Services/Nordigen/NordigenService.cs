using Fint.Web.Models.Nordigen;
using Fint.Web.Models.Nordigen.Authentication;
using Fint.Web.Services.Nordigen.Interfaces;
using HttpClientWrapper;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientWrapper.Constants;
using Fint.Web.Constants;
using HttpClientWrapper.Interfaces;

namespace Fint.Web.Services.Nordigen
{
    public class NordigenService : INordigenService
    {
        private IHttpClientService httpClientService;

        public NordigenService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService; 
        }

        public async Task<BearerTokenData> GetBearerToken()
        {
            //Change to get from database
            var tokenRequest = new TokenRequest()
            {
                SecretId = "eac8ccd3-7642-4c74-bfff-36779d518337",
                SecretKey = "de5027f5b9875afc34f8476d85ec8975fd04116e50f98f9650376e1d9f1fd94707c3be4110f4c659645de786e1bf80c113944ffc44c31ad1d4db17a0ce48f3e5",
            };

            var bearerTokenRequestBuilder = RequestBuilder.CreateRequest()
                            .HttpMethod(HttpMethod.Post)
                            .WithHeader(HttpRequestContants.HeaderName.Accept, HttpRequestContants.HeaderValue.ApplicationJson)
                            //.WithHeader(HttpRequestContants.HeaderName.ContentType, HttpRequestContants.HeaderValue.ApplicationJson)
                            .Endpoint(NordigenApiConstants.EndPoints.NewBearerToken)
                            .WithBodyAsJson(tokenRequest);

            return await Task.FromResult(httpClientService.SendRequest<BearerTokenData>(bearerTokenRequestBuilder));


        }

        public Task<AccountDetails> GetUserAccount()
        {
            throw new NotImplementedException();
        }

        public Task<BearerTokenData> RefreshBearerToken()
        {
            throw new NotImplementedException();
        }
    }
}