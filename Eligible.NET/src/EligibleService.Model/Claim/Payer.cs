using Newtonsoft.Json;

namespace EligibleService.Model.Claim
{
    public class ClaimPayer
    {
        /// <summary>
        /// Required To Create a Claim.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Required To Create a Claim.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        [JsonProperty("responsibility_sequence")]
        public string ResponsibilitySequence { get; set; }

        /// <summary>
        /// Required To Create a Claim.
        /// </summary>
        [JsonProperty("address")]
        public Address Address { get; set; }
    }

    public class OtherPayers : ClaimPayer
    {
        [JsonProperty("claim_filing_indicator")]
        public string ClaimFilingIndicator { get; set; }

        [JsonProperty("secondary_id_type")]
        public string SecondaryIdType { get; set; }

        [JsonProperty("secondary_id")]
        public string SecondaryId { get; set; }

        [JsonProperty("prior_authorization_number")]
        public string PriorAuthorizationNumber { get; set; }

        [JsonProperty("referral_number")]
        public string ReferralNumber { get; set; }

        [JsonProperty("subscriber")]
        public Subscriber Subscriber { get; set; }

        [JsonProperty("cob")]
        public Cob Cob { get; set; }
    }
}
