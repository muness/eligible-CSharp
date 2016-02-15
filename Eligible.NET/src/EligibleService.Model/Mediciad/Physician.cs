using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.Medicaid
{
    public class Physician
    {
        [JsonProperty("eligibility_code")]
        public string EligibilityCode { get; set; }

        [JsonProperty("eligibility_code_label")]
        public string EligibilityCodeLabel { get; set; }

        [JsonProperty("primary_care")]
        public bool? PrimaryCare { get; set; }

        [JsonProperty("contact_details")]
        public Collection<ContactDetail> ContactDetails { get; set; }
    }

}
