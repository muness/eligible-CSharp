using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class CrossoverPayer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

}
