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
}
