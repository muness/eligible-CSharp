using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Model.EnrollmentNpis
{
    public class EnrollmentNpi
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("effective_date")]
        public string EffectiveDate { get; set; }

        [JsonProperty("facility_name")]
        public string FacilityName { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("npi")]
        public string Npi { get; set; }

        [JsonProperty("provider_name")]
        public string ProviderName { get; set; }

        [JsonProperty("ptan")]
        public string Ptan { get; set; }

        [JsonProperty("medicaid_id")]
        public string MedicaidId { get; set; }

        [JsonProperty("reject_reasons")]
        public Collection<string> RejectReasons { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tax_id")]
        public string TaxId { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("original_signature_pdf")]
        public OriginalSignaturePdf OriginalSignaturePdf { get; set; }

        [JsonProperty("received_pdf")]
        public ReceivedPdf ReceivedPdf { get; set; }

        [JsonProperty("authorized_signer")]
        public AuthorizedSigner AuthorizedSigner { get; set; }

        [JsonProperty("payer")]
        public EnrollmentPayer Payer { get; set; }
    }

}
