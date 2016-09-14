using Newtonsoft.Json;

namespace EligibleService.Model.Precertification
{
    public class Certification
    {
        [JsonProperty("action_code")]
        public string ActionCode { get; set; }

        [JsonProperty("action_label")]
        public string ActionLabel { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("decision_code")]
        public string DecisionCode { get; set; }

        [JsonProperty("decision_label")]
        public string DecisionLabel { get; set; }

        [JsonProperty("admin_ref_number")]
        public string AdminRefNumber { get; set; }

        [JsonProperty("previous_review_auth_number")]
        public string PreviousReviewAuthNumber { get; set; }

        [JsonProperty("issue_date")]
        public string IssueDate { get; set; }

        [JsonProperty("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonProperty("effective_start_date")]
        public string EffectiveStartDate { get; set; }

        [JsonProperty("effective_end_date")]
        public string EffectiveEndDate { get; set; }
    }

}
