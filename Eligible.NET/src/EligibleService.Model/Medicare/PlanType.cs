using Newtonsoft.Json;

namespace EligibleService.Model.Medicare
{
    /// <summary>
    /// Medicare Plan Type
    /// </summary>
    public class PlanType
    {
        [JsonProperty("MA")]
        public string MA { get; set; }

        [JsonProperty("MB")]
        public string MB { get; set; }

        [JsonProperty("MC")]
        public string MC { get; set; }

        [JsonProperty("MD")]
        public string MD { get; set; }

        [JsonProperty("PR")]
        public string PR { get; set; }
    }
}
