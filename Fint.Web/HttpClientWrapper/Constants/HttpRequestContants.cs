using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientWrapper.Constants
{
    public static class HttpRequestContants
    {
        public struct HeaderName
        {
            public static string Accept => "Accept";
            public static string ContentType => "Content-Type";
            public static string Authorization => "Authorization";
        }
        public struct HeaderValue
        {
            public static string ApplicationJson => "application/json";
            public static string Bearer => "Bearer ";
        }
    }
}
