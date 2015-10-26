using Newtonsoft.Json;

namespace EligibleService.Model.PaymentStatus
{
    public class Code
    {
        [JsonProperty("category_code")]
        public string CategoryCode { get; set; }

        [JsonProperty("category_label")]
        public string CategoryLabel { get; set; }

        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

        [JsonProperty("status_label")]
        public string StatusLabel { get; set; }

        [JsonProperty("entity_code")]
        public string EntityCode { get; set; }

        [JsonProperty("entity_label")]
        public string EntityLabel { get; set; }
    }

}
