using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class Actual
    {
        [JsonProperty("covered")]
        public int? Covered { get; set; }

        [JsonProperty("co_insured")]
        public int? COInsured { get; set; }

        [JsonProperty("life_time_reserve")]
        public int? LifetimeReserve { get; set; }
    }

}
