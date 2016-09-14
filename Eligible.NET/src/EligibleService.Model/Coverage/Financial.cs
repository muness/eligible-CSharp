using Newtonsoft.Json;

namespace EligibleService.Model.Coverage
{
    public class Financial : FinancialRemainings
    {
        [JsonProperty("spent")]
        public FinancialFlows Spent { get; set; }

        [JsonProperty("totals")]
        public FinancialFlows Totals { get; set; }
    }

    public class FinancialRemainings
    {
        [JsonProperty("remainings")]
        public FinancialFlowsRemainings Remainings { get; set; }
    }

    public class StopLossFinancial
    {
        [JsonProperty("spent")]
        public StopLossFinancialFlows Spent { get; set; }

        [JsonProperty("totals")]
        public StopLossFinancialFlowTotals Totals { get; set; }

        [JsonProperty("remainings")]
        public StopLossFinancialFlows Remainings { get; set; }
    }
}
