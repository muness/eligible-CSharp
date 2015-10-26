using Newtonsoft.Json;
using System;

namespace EligibleService.Model
{
    /// <summary>
    /// Date Format used by Coverage and Medicare
    /// </summary>
    public class Dates
    {
        [JsonProperty("date_type")]
        public string DateType { get; set; }

        [JsonProperty("date_value")]
        public string DateValue { get; set; }
    }
}
