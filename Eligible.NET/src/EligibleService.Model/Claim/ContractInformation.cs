using Newtonsoft.Json;

namespace EligibleService.Model.Claim
{
    public class ContractInformation
    {
        [JsonProperty("contract_type_code")]
        public string ContractTypeCode { get; set; }

        [JsonProperty("monetary_amount")]
        public string MonetaryAmount { get; set; }

        [JsonProperty("percent")]
        public string Percent { get; set; }

        [JsonProperty("contract_id")]
        public string ContractId { get; set; }

    }
}
