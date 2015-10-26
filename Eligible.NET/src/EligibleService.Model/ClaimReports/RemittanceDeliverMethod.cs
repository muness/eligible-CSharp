using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class RemittanceDeliverMethod
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("code_label")]
        public string CodeLabel { get; set; }   

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("communication_number")]
        public string CommunicationNumber { get; set; }
    }
}
