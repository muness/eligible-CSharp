using EligibleService.Model.CostEstimates;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Medicare
{
    /// <summary>
    /// Medicare serive model
    /// </summary>
    public class MedicareService : PaymentDetails
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("type_label")]
        public string TypeLabel { get; set; }

        [JsonProperty("plan_type")]
        public string PlanType { get; set; }

        [JsonProperty("active")]
        public bool? Active { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }


        [JsonProperty("visits")]
        public Collection<Visits> Visits { get; set; }

    }
}
