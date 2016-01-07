using EligibleService.Model;
using EligibleService.Model.EnrollmentNpis;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Core.EnrollmentNpis
{
    public class EnrollmentParams : BasicParams
    {
        [JsonProperty("enrollment_npi")]
        public EnrollmentNpi EnrollmentNpi { get; set; }
    }

    public class EnrollmentNpi
    {
        [JsonProperty("payer_id")]
        public string PayerId { get; set; }

        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("effective_date")]
        public string EffectiveDate { get; set; }

        [JsonProperty("facility_name")]
        public string FacilityName { get; set; }

        [JsonProperty("provider_name")]
        public string ProviderName { get; set; }

        [JsonProperty("tax_id")]
        public string TaxId { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("ptan")]
        public string Ptan { get; set; }

        [JsonProperty("medicaid_id")]
        public string MedicaidId { get; set; }

        [JsonProperty("npi")]
        public string Npi { get; set; }

        [JsonProperty("authorized_signer")]
        public AuthorizedSigner AuthorizedSigner { get; set; }

    }

    public class AuthorizedSigner
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("contact_number")]
        public string ContactNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("signature")]
        public Signature Signature { get; set; }
    }

    public class Signature
    {
        [JsonProperty("coordinates")]
        public Collection<Coordinate> Coordinates { get; set; }
    }
}
