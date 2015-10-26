using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.Medicaid
{
    public class Medicaid
    {
        [JsonProperty("coverage")]
        public string Coverage { get; set; }

        [JsonProperty("benefit_description")]
        public string BenefitDescription { get; set; }

        [JsonProperty("physicians")]
        public Collection<Physician> Physicians { get; set; }

        [JsonProperty("managed_care")]
        public Collection<ManagedCare> ManagedCare { get; set; }

        [JsonProperty("provider_care_restriction")]
        public Collection<object> ProviderCareRestriction { get; set; }

        [JsonProperty("nursing_home")]
        public Collection<object> NursingHome { get; set; }
    }

}
