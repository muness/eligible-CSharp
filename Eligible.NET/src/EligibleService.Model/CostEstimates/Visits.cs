using Newtonsoft.Json;

namespace EligibleService.Model.CostEstimates
{
    public class Visits
    {
        [JsonProperty("base")]
        public int? Base { get; set; }

        [JsonProperty("remaining")]
        public int? Remaining { get; set; }

        [JsonProperty("next_eligible_date")]
        public string NextEligibleDate { get; set; }
    }
}
