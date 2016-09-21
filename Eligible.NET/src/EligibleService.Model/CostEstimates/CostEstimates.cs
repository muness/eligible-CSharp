using EligibleService.Exceptions;
using EligibleService.Model.CostEstimates;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model
{
    public class CostEstimatesResponse : CoverageResponse
    {
        [JsonProperty("cost_estimates")]
        public Collection<CostEstimateClass> CostEstimates { get; set; }

        [JsonProperty("warnings")]
        public Collection<CostEstimateWarnings> Warnings { get; set; }

        [JsonProperty("success")]
        public bool? Success { get; set; }
    }

    public class CostEstimateMedicareResponse : MedicareResponse
    {
        [JsonProperty("cost_estimates")]
        public Collection<CostEstimateMedicare> CostEstimates { get; set; }

        [JsonProperty("success")]
        public bool? Success { get; set; }
    }
}
