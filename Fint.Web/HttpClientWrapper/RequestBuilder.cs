using HttpClientWrapper.Extensions;
using HttpClientWrapper.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HttpClientWrapper
{
    public class RequestBuilder : IRequestBuilder
    {
        private readonly HttpRequestMessage _httpRequestMessage;
        public RequestBuilder()
        {
            _httpRequestMessage = new HttpRequestMessage();
        }

        public static RequestBuilder CreateRequest()
        {
            return new RequestBuilder();
        }

        public IRequestBuilder AddFormUrlEncodedContentItem(string key, string value)
        {
            throw new NotImplementedException();
        }

        public IRequestBuilder AddStringContent(string content, Encoding encoding = null, string mediaType = null)
        {
            throw new NotImplementedException();
        }

        public HttpRequestMessage Build()
        {
            return this._httpRequestMessage;
        }

        public IRequestBuilder Endpoint(string url)
        {
            _httpRequestMessage.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
            return this;
        }

        public IRequestBuilder HttpMethod(HttpMethod httpMethod)
        {
            _httpRequestMessage.Method = httpMethod;
            return this;
        }

        public IRequestBuilder WithBasicAuthenticationHeader(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IRequestBuilder WithBearerAuthenticationHeader(string token)
        {
            _httpRequestMessage.Headers.AddRequestBearerAuthenticationHeader(token);
            return this;
        }

        public IRequestBuilder WithBodyAsJson<T>(T model)
        {
            if (model == null)
            {
                throw new ArgumentException("Error in WithBodyAsJson");
            }
            else
            {
                var jsonData = JsonConvert.SerializeObject(model);
                _httpRequestMessage.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            }
            return this;
        }

        public IRequestBuilder WithBodyAsJson(string jsonString)
        {
            throw new NotImplementedException();
        }

        public IRequestBuilder WithHeader(string name, string value)
        {
            _httpRequestMessage.Headers.Add(name, value);
            return this;
        }

        public IRequestBuilder WithHeaders(IDictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }

        public IRequestBuilder WithOauthAuthenticationHeader(string token)
        {
            throw new NotImplementedException();
        }

        public IRequestBuilder WithTimeoutInMilliSeconds(int timeoutMilliseconds)
        {
            throw new NotImplementedException();
        }
    }
}

