using Newtonsoft.Json;

namespace EligibleService.Model.CostEstimates
{
    public class StopLoss
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("copayment")]
        public bool? Copayment { get; set; }

        [JsonProperty("coinsurance")]
        public bool? Coinsurance { get; set; }

        [JsonProperty("deductible")]
        public bool? Deductible { get; set; }
    }

}
