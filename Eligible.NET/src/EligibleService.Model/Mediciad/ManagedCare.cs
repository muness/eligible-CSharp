using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.Medicaid
{
    public class ManagedCare
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("dates")]
        public Collection<EligibleService.Model.Dates> Dates { get; set; }

        [JsonProperty("contact_details")]
        public Collection<ContactDetail> ContactDetails { get; set; }
    }

}
