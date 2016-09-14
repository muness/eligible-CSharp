using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class Financials
    {
        [JsonProperty("deductible")]
        public Financial Deductible { get; set; }

        [JsonProperty("stop_loss")]
        public StopLossFinancial StopLoss { get; set; }

        [JsonProperty("coinsurance")]
        public FinancialFlowsPercents Coinsurance { get; set; }

        [JsonProperty("copayment")]
        public FinancialFlowsAmounts Copayment { get; set; }

        [JsonProperty("cost_containment")]
        public Financial CostContainment { get; set; }

        [JsonProperty("spend_down")]
        public Financial SpendDown { get; set; }

        [JsonProperty("limitations")]
        public LimitationsFinancialFlowsList Limitations { get; set; }

        [JsonProperty("disclaimer")]
        public Collection<String> Disclaimer { get; set; }

        [JsonProperty("other_sources")]
        public FinancialFlowsList OtherSources { get; set; }

        [JsonProperty("reserve")]
        public FinancialRemainings Reserve { get; set; }
    }
}
