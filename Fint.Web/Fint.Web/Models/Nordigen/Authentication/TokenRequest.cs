using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fint.Web.Models.Nordigen.Authentication
{
    public class TokenRequest
    {
        [JsonProperty("secret_id")]
        public string SecretId { get; set; }

        [JsonProperty("secret_key")]
        public string SecretKey { get; set; }
    }
}