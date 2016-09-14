using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class FinancialFlows
    {
        [JsonProperty("in_network")]
        public Collection<FinancialFlow> InNetwork { get; set; }
        [JsonProperty("out_network")]
        public Collection<FinancialFlow> OutNetwork { get; set; }
    }

    public class FinancialFlowsRemainings
    {
        [JsonProperty("in_network")]
        public Collection<FinancialFlowRemainings> InNetwork { get; set; }
        [JsonProperty("out_network")]
        public Collection<FinancialFlowRemainings> OutNetwork { get; set; }
    }


    public class StopLossFinancialFlows
    {
        [JsonProperty("in_network")]
        public Collection<StopLossFinancialFlow> InNetwork { get; set; }
        [JsonProperty("out_network")]
        public Collection<StopLossFinancialFlow> OutNetwork { get; set; }
    }

    public class StopLossFinancialFlowTotals
    {
        [JsonProperty("in_network")]
        public Collection<StopLossFinancialFlowTotal> InNetwork { get; set; }
        [JsonProperty("out_network")]
        public Collection<StopLossFinancialFlowTotal> OutNetwork { get; set; }
    }
}
