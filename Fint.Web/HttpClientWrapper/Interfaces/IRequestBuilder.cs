using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientWrapper.Interfaces
{
    public interface IRequestBuilder
    {
        IRequestBuilder Endpoint(string url);
        IRequestBuilder HttpMethod(HttpMethod httpMethod);

        #region Add Headers Headers
        IRequestBuilder WithHeader(string name, string value);
        IRequestBuilder WithHeaders(IDictionary<string, string> headers);
        IRequestBuilder WithBasicAuthenticationHeader(string username, string password);
        IRequestBuilder WithOauthAuthenticationHeader(string token);
        IRequestBuilder WithBearerAuthenticationHeader(string token);
        #endregion

        IRequestBuilder WithTimeoutInMilliSeconds(int timeoutMilliseconds);

        #region Add HTTP Content
        IRequestBuilder AddFormUrlEncodedContentItem(string key, string value);
        IRequestBuilder AddStringContent(string content, Encoding encoding = null, string mediaType = null);
        IRequestBuilder WithBodyAsJson<T>(T model);
        IRequestBuilder WithBodyAsJson(string jsonString);
        #endregion

        HttpRequestMessage Build();
    }
}
