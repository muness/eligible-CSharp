using Newtonsoft.Json;

namespace EligibleService.Model.CostEstimates
{
    public class CostEstimateClass
    {
        [JsonProperty("cost_estimate_equation")]
        public CostEstimateEquation CostEstimateEquation { get; set; }

        [JsonProperty("cost_estimate_alternatives")]
        public CostEstimateAlternatives CostEstimateAlternatives { get; set; }

        [JsonProperty("cost_estimate")]
        public double? CostEstimate { get; set; }

        [JsonProperty("provider_price")]
        public double? ProviderPrice { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }
    }
}
