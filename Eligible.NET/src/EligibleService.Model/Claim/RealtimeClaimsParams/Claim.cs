using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.RealtimeClaimParams
{
    public class Claim
    {
        [JsonProperty("patient_signature_on_file")]
        public string PatientSignatureOnFile { get; set; }

        [JsonProperty("direct_payment_authorized")]
        public string DirectPaymentAuthorized { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        [JsonProperty("prior_authorization_number")]
        public string PriorAuthorizationNumber { get; set; }

        [JsonProperty("accept_assignment_code")]
        public string AcceptAssignmentCode { get; set; }

        [JsonProperty("total_charge")]
        public string TotalCharge { get; set; }

        [JsonProperty("patient_amount_paid")]
        public string PatientAmountPaid { get; set; }

        [JsonProperty("provider_signature_on_file")]
        public string ProviderSignatureOnFile { get; set; }

        [JsonProperty("diagnosis_codes")]
        public Collection<string> DiagnosisCodes { get; set; }

        [JsonProperty("service_lines")]
        public Collection<ServiceLine> ServiceLines { get; set; }
    }

}
