using Newtonsoft.Json;

namespace EligibleService.Model.Precertification
{
    public class Delivery
    {
        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        [JsonProperty("time_period")]
        public string TimePeriod { get; set; }

        [JsonProperty("time_period_qualifier")]
        public string TimePeriodQualifier { get; set; }
    }

}
