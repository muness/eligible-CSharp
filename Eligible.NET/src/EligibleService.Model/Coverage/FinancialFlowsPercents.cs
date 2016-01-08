using Newtonsoft.Json;

namespace EligibleService.Model.Coverage
{
    public class FinancialFlowsPercents
    {
        [JsonProperty("percents")]
        public FinancialFlows Percents { get; set; }
    }
}
