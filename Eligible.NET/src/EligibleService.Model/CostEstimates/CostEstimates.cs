using EligibleService.Model.CostEstimates;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model
{
    public class CostEstimatesResponse : CoverageResponse
    {
        [JsonProperty("cost_estimates")]
        public Collection<CostEstimateClass> CostEstimates { get; set; }
    }

}
