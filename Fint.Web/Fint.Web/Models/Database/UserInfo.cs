using Fint.Web.Models.Authentication.Interfaces;
using Fint.Web.Models.Nordigen;
using Fint.Web.Models.Nordigen.Authentication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fint.Web.Models.Database
{
    public class UserInfo
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("token_data")]
        public BearerTokenData TokenData { get; set; }
        [JsonProperty("account")]
        public AccountDetails Account { get; set; }

    }
}