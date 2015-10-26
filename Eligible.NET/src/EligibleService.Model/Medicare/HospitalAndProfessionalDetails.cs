using Newtonsoft.Json;
using System;

namespace EligibleService.Model.Medicare
{
    /// <summary>
    /// Medicare Hospital and Professional Model
    /// </summary>
    public class HospitalAndProfessionalDetails : PaymentDetails
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }
    }
}
