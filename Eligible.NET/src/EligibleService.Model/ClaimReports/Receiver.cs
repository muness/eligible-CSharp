using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class RecieverSenderBase
    {
        [JsonProperty("dfi_id_qualifier")]
        public string DfiIdQualifier { get; set; }

        [JsonProperty("dfi_id_qualifier_label")]
        public string DfiIdQualifierLabel { get; set; }

        [JsonProperty("dfi_id")]
        public string DfiId { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
    }

    public class Receiver : RecieverSenderBase
    {
        [JsonProperty("account_type")]
        public string AccountType { get; set; }
    }

}
