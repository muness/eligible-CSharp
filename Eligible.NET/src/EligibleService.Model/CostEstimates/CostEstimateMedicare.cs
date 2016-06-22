using Newtonsoft.Json;

namespace EligibleService.Model.CostEstimates
{
    public class CostEstimateMedicare
    {
        [JsonProperty("cost_estimate_equation")]
        public CostEstimateEquationMedicare CostEstimateEquation { get; set; }

        [JsonProperty("cost_estimate_alternatives")]
        public CostEstimateAlternativesMedicare CostEstimateAlternatives { get; set; }

        [JsonProperty("cost_estimate")]
        public double? CostEstimate { get; set; }

        [JsonProperty("provider_price")]
        public double? ProviderPrice { get; set; }
    }
}
