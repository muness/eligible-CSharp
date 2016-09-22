using Newtonsoft.Json;

namespace EligibleService.Model.CostEstimates
{
    public class Coinsurance : PaymentBase 
    {
        [JsonProperty("percent")]
        public string Percent { get; set; }

        [JsonProperty("time_period")]
        public string TimePeriod { get; set; }

        [JsonProperty("time_period_label")]
        public string TimePeriodLabel { get; set; }

        [JsonProperty("service_delivery")]
        public ServiceDelivery ServiceDelivery { get; set; }

        [JsonProperty("service_type")]
        public string ServiceType { get; set; }
    }

    public class Deductible : PaymentBase
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("service_delivery")]
        public ServiceDelivery ServiceDelivery { get; set; }

        [JsonProperty("service_type")]
        public string ServiceType { get; set; }
    }
}
