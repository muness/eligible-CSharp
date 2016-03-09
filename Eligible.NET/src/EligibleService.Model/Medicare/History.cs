using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Medicare
{
    public class History
    {
        [JsonProperty("plan_details")]
        public HistoryPlanDetails PlanDetails { get; set; }

        [JsonProperty("requested_service_types")]
        public Collection<MedicareService> RequestedServiceTypes { get; set; }
    }

    public class HistoryPlanDetails
    {
        [JsonProperty("MA")]
        public Collection<HospitalAndProfessionalDetails> MA { get; set; }

        [JsonProperty("MB")]
        public Collection<HospitalAndProfessionalDetails> MB { get; set; }

        [JsonProperty("MC")]
        public Collection<MCDetails> MC { get; set; }

        [JsonProperty("MD")]
        public Collection<BasicDetails> MD { get; set; }

        [JsonProperty("PR")]
        public Collection<BasicDetails> PR { get; set; }
    }
}
