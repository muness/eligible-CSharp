using Newtonsoft.Json;

namespace EligibleService.Model.Claim
{
    public class BillingProvider : Person
    {
        /// <summary>
        /// Required for creating a Claim.
        /// Tax id for provider based on type mentioned in tax_id_type. ex: tax_id: "123456789"
        /// </summary>
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }

        /// <summary>
        /// Required for creating a Claim.
        /// type of tax id of provider. Possible values are EI(employer's identification number) or SY(SSN) and default value is set as EI. ex: "tax_id_type": "EI"
        /// </summary>
        /// 
        [JsonProperty("tax_id_type")]
        public string TaxIdType { get; set; }

        /// <summary>
        /// Optional for creating a Claim.
        /// if billing provider is an organizational entity or not. Possible values are true or false, and default value is false. ex: "entity": true
        /// </summary>
        [JsonProperty("entity")]
        public string Entity { get; set; }

        /// <summary>
        /// Required depends on situation
        /// name of organizational entity. It is required when entity is set as true and will be ignored if entity is set to false. ex: "organization_name": "Some Practice"
        /// </summary>
        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Required for creating a Claim.
        /// valid NPI number of provider. ex: "npi": "1111111111"
        /// </summary>
        [JsonProperty("npi")]
        public string Npi { get; set; }

        /// <summary>
        /// Required for creating a Claim.
        /// Code identifying the type of provider. Required when the payer’s adjudication is known to be impacted by the provider taxonomy code. ex: "taxonomy_code": "332B00000X"
        /// </summary>
       [JsonProperty("taxonomy_code")]
        public string TaxonomyCode { get; set; }

        /// <summary>
        /// Required but depends on Situation
        /// if the insurance assigns the provider/healthcare professional, etc a specific ID number in addition to their NPI. A good example of this is a Medicare PTAN number. ex: "insurance_provider_id": "1234567890"
        /// </summary>
        [JsonProperty("insurance_provider_id")]
        public string InsuranceProviderId { get; set; }
    }
}
