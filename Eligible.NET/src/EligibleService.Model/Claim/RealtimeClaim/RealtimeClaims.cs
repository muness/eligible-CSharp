using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using EligibleService.Claim.RealtimeClaims;

namespace EligibleService.Model
{
    public class RealtimeClaimsResponse : JsonResponseClass
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

        [JsonProperty("status_label")]
        public string StatusLabel { get; set; }

        [JsonProperty("acknowledgements")]
        public Collection<object> Acknowledgements { get; set; }

        [JsonProperty("report")]
        public Report Report { get; set; }
    }

}
