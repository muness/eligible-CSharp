using Newtonsoft.Json;

namespace EligibleService.Claim.RealtimeClaimParams
{
    public class RenderingProvider
    {
        [JsonProperty("entity")]
        public bool? Entity { get; set; }

        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("npi")]
        public string Npi { get; set; }
    }

}
