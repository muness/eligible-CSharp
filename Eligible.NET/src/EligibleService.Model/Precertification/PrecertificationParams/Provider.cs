using EligibleService.Model;
using Newtonsoft.Json;

namespace EligibleService.Claim.Precert
{
    public class Provider
    {
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("npi")]
        public string Npi { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

}
