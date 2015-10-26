using EligibleService.Model.CostEstimates;
using EligibleService.Model.Coverage;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace EligibleService.Model
{


    public class CostEstimatesResponse : CoverageResponse
    {
        [JsonProperty("cost_estimates")]
        public Collection<CostEstimateClass> CostEstimates { get; set; }

    }

}
