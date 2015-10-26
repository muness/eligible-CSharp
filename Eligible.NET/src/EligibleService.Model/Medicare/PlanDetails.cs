using Newtonsoft.Json;

namespace EligibleService.Model.Medicare
{
    /// <summary>
    /// Medicare Plan Details model
    /// </summary>
    public class PlanDetails
    {
        [JsonProperty("MA")]
        public HospitalAndProfessionalDetails MA { get; set; }

        [JsonProperty("MB")]
        public HospitalAndProfessionalDetails MB { get; set; }

        [JsonProperty("MC")]
        public MCDetails MC { get; set; }

        [JsonProperty("MD")]
        public BasicDetails MD { get; set; }

        [JsonProperty("PR")]
        public BasicDetails PR { get; set; }
    }
}
