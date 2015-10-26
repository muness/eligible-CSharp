
using Newtonsoft.Json;
namespace EligibleService.Model.Coverage
{
    public class FinancialFlowsAmounts
    {
        [JsonProperty("amounts")]
        public FinancialFlows Amounts { get; set; }
    }
}
