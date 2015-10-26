using Newtonsoft.Json;

namespace EligibleService.Claim.Precert
{
    public class PrecertPayer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

}
