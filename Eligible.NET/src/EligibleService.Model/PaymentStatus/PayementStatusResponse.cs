using EligibleService.Model.PaymentStatus;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace EligibleService.Model
{


    public class PayementStatusResponse : JsonResponseClass
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }

        [JsonProperty("known_issues")]
        public string KnownIssues { get; set; }

        [JsonProperty("payer")]
        public PayementPayer Payer { get; set; }

        [JsonProperty("service_provider")]
        public Collection<EligibleService.Claim.ClaimReports.ServiceProvider> ServiceProvider { get; set; }

        [JsonProperty("patients")]
        public Collection<EligibleService.Claim.ClaimReports.Patient> Patients { get; set; }

        [JsonProperty("claims")]
        public Collection<PaymentClaim> Claims { get; set; }
    }

}
