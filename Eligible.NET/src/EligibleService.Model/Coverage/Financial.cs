
using Newtonsoft.Json;
namespace EligibleService.Model.Coverage
{
    public class Financial
    {
        [JsonProperty("remainings")]
        public FinancialFlows Remainings { get; set; }

        [JsonProperty("spent")]
        public FinancialFlows Spent { get; set; }

        [JsonProperty("totals")]
        public FinancialFlows Totals { get; set; }
    }
}
