using Newtonsoft.Json;

namespace EligibleService.Model.Precertification
{

    public class ServiceCertification : Certification
    {
        [JsonProperty("service_start_date")]
        public string ServiceStartDate { get; set; }

        [JsonProperty("service_end_date")]
        public string ServiceEndDate { get; set; }

        [JsonProperty("issue_date")]
        public string IssueDate { get; set; }

    }

}
