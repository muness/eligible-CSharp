using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class Sender : RecieverSenderBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("supplemental_code")]
        public string SupplementalCode { get; set; }
    }

}
