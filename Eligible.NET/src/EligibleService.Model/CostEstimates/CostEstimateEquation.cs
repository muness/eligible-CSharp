using EligibleService.Model.Coverage;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.CostEstimates
{
    public class CostEstimateEquation
    {
        [JsonProperty("deductible")]
        public Collection<Deductible> Deductible { get; set; }

        [JsonProperty("coinsurance")]
        public Collection<Coinsurance> Coinsurance { get; set; }

        [JsonProperty("copayment")]
        public Collection<Copayment> Copayment { get; set; }

        [JsonProperty("stop_loss")]
        public Collection<StopLoss> StopLoss { get; set; }

        [JsonProperty("applied_amounts")]
        public AppliedAmounts AppliedAmounts { get; set; }
    }

}
