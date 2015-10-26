using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class Estimated
    {
        [JsonProperty("life_time_reserve")]
        public int? LifetimeReserve { get; set; }

        [JsonProperty("non_covered")]
        public int? NonCovered { get; set; }
    }

}
