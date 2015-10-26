using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    /// <summary>
    /// Coverage AdditionalInsurancePolicy model 
    /// </summary>
    public class AdditionalInsurancePolicy
    {
        [JsonProperty("insurance_type")]
        public string InsuranceType { get; set; }

        [JsonProperty("coverage_description")]
        public string CoverageDescription { get; set; }

        [JsonProperty("reference")]
        public Collection<Reference> Reference { get; set; }

        [JsonProperty("payer_type")]
        public string PayerType { get; set; }

        [JsonProperty("payer_type_label")]
        public string PayerTypeLabel { get; set; }

        [JsonProperty("contact_details")]
        public Collection<ContactDetail> ContactDetails { get; set; }

        [JsonProperty("dates")]
        public Collection<Dates> Dates { get; set; }

        [JsonProperty("comments")]
        public Collection<String> Comments { get; set; }

        [JsonProperty("service_type_codes")]
        public Collection<String> ServiceTypeCodes { get; set; }
    }
}
