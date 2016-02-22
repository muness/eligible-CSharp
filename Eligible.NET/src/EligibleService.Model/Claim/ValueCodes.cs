using Newtonsoft.Json;

namespace EligibleService.Model.Claim
{
    public class ValueCodes
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }
    }
}
