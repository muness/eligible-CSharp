using Newtonsoft.Json;

namespace EligibleService.Claim.RealtimeClaims
{
    public class Detail
    {
        [JsonProperty("type_code")]
        public string TypeCode { get; set; }

        [JsonProperty("type_label")]
        public string TypeLabel { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
