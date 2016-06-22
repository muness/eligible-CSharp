using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.CostEstimates
{
    public class CostEstimateAlternativesMedicare
    {
        [JsonProperty("deductible")]
        public Collection<Estimate> Deductible { get; set; }

        [JsonProperty("coinsurance")]
        public Collection<Estimate> Coinsurance { get; set; }

        [JsonProperty("copayment")]
        public Collection<Estimate> Copayment { get; set; }

        [JsonProperty("stop_loss")]
        public Collection<Estimate> StopLoss { get; set; }
    }

    public class CostEstimateEquationMedicare : CostEstimateAlternativesMedicare
    {
        [JsonProperty("applied_amounts")]
        public AppliedAmounts AppliedAmounts { get; set; }
    }
}
