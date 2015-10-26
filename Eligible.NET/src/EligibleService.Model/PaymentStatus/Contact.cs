using EligibleService.Claim.ClaimReports;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.PaymentStatus
{
    public class Contact
    {
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        [JsonProperty("department_label")]
        public string DepartmentLabel { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("details")]
        public Collection<Detail> Details { get; set; }
    }
}
