using EligibleService.Model.Coverage;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.CostEstimates
{
    public class CostEstimateEquation
    {
        [JsonProperty("deductible")]
        public Collection<Collection<FinancialFlow>> Deductible { get; set; }

        [JsonProperty("coinsurance")]
        public Collection<FinancialFlowsPercents> Coinsurance { get; set; }

        [JsonProperty("copayment")]
        public Collection<FinancialFlowsAmounts> Copayment { get; set; }

        [JsonProperty("stop_loss")]
        public Collection<Financial> StopLoss { get; set; }
    }

}
