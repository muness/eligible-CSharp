using EligibleService.Model;
using Newtonsoft.Json;

namespace EligibleService.Claim.Precert
{
    public class Requester
    {
        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("npi")]
        public string Npi { get; set; }
    }

}
