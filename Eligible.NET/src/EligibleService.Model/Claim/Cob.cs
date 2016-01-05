using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Claim
{
    public class Cob
    {
        [JsonProperty("payer_id")]
        public string PayerId { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("assigned_number")]
        public string AssignedNumber { get; set; }

        [JsonProperty("procedure_code")]
        public string ProcedureCode { get; set; }

        [JsonProperty("procedure_modifiers")]
        public Collection<string> ProcedureModifiers { get; set; }

        [JsonProperty("claim_control_number")]
        public string ClaimControlNumber { get; set; }

        [JsonProperty("amount_paid")]
        public string AmountPaid { get; set; }

        [JsonProperty("non_covered_amount")]
        public string NonCoveredAmount { get; set; }

        [JsonProperty("remaining_patient_liability")]
        public string RemainingPatientLiability { get; set; }

        [JsonProperty("adjudication_date")]
        public string AdjudicationDate { get; set; }

        [JsonProperty("adjustment_group_code")]
        public string AdjustmentGroupCode { get; set; }

        [JsonProperty("adjustments")]
        public Adjustments Adjustments { get; set; }

        [JsonProperty("outpatient_adjuducation_information")]
        public Collection<OutpatientAdjuducationInformation> OutpatientAdjuducationInformation { get; set; }
    }
}
