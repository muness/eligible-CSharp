using Newtonsoft.Json;

namespace EligibleService.Model.CostEstimates
{
    public class Copayment : PaymentBase
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("time_period")]
        public string TimePeriod { get; set; }

        [JsonProperty("time_period_label")]
        public string TimePeriodLabel { get; set; }

        [JsonProperty("service_delivery")]
        public ServiceDelivery ServiceDelivery { get; set; }
    }

}
