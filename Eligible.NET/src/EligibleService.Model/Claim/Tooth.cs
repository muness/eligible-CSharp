using Newtonsoft.Json;

namespace EligibleService.Model.Claim
{
    public class Tooth
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("status_code")]
        public string StatusCode { get; set; }
    }
}
