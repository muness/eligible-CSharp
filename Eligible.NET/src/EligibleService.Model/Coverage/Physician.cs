using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class Physician
    {
        [JsonProperty("eligibility_code")]
        public string EligibilityCode { get; set; }

        [JsonProperty("eligibility_code_label")]
        public string EligibilityCodeLabel { get; set; }

        [JsonProperty("insurance_type")]
        public string InsuranceType { get; set; }

        [JsonProperty("insurance_type_label")]
        public string InsuranceTypeLabel { get; set; }

        [JsonProperty("primary_care")]
        public bool PrimaryCare { get; set; }

        [JsonProperty("restricted")]
        public string Restricted { get; set; }

        [JsonProperty("contact_details")]
        public Collection<ContactDetail> ContactDetails { get; set; }

        [JsonProperty("dates")]
        public Collection<Dates> Dates { get; set; }

        [JsonProperty("comments")]
        public Collection<String> Comments { get; set; }
    }
}
