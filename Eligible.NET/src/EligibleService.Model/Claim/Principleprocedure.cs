using Newtonsoft.Json;

namespace EligibleService.Model.Claim
{
    public class Principleprocedure
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
