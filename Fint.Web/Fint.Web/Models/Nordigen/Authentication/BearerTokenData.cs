using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fint.Web.Models.Nordigen.Authentication
{
    public class BearerTokenData
    {
        [JsonProperty("access")]
        public string Access { get; set; }

        [JsonProperty("access_expires")]
        public int AccessExpires { get; set; }

        [JsonProperty("refresh")]
        public string Refresh { get; set; }

        [JsonProperty("refresh_expires")]
        public int RefreshExpires { get; set; }
    }
}