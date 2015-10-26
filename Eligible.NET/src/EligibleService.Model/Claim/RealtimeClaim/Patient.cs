using EligibleService.Model;
using Newtonsoft.Json;

namespace EligibleService.Claim.RealtimeClaims
{
    public class Patient : Name
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

}
