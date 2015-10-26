using Newtonsoft.Json;

namespace EligibleService.Claim.Precert
{
    public class Diagnosi
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }

}
