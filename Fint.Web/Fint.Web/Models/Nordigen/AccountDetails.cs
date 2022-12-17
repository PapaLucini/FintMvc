using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fint.Web.Models.Nordigen
{
    public class AccountDetails
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("last_accessed")]
        public DateTime LastAccessed { get; set; }

        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("institution_id")]
        public string InstitutionId { get; set; }

        [JsonProperty("owner_name")]
        public string OwnerName { get; set; }
    }
}