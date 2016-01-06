using Newtonsoft.Json;
using EligibleService.Model;

namespace EligibleService.Claim.RealtimeClaimParams
{
    public class Payer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

}
