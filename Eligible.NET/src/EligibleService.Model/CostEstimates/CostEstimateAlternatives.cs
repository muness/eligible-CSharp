using EligibleService.Model.Coverage;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.CostEstimates
{
    public class CostEstimateAlternatives
    {
        [JsonProperty("deductible")]
        public Collection<Coinsurance> Deductible { get; set; }

        [JsonProperty("coinsurance")]
        public Collection<Coinsurance> Coinsurance { get; set; }

        [JsonProperty("copayment")]
        public Collection<Copayment> Copayment { get; set; }

        [JsonProperty("stop_loss")]
        public Collection<StopLoss> StopLoss { get; set; }
    }

}
