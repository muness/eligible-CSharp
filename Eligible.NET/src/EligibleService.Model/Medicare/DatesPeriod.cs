using Newtonsoft.Json;
using System;

namespace EligibleService.Model.Medicare
{
    /// <summary>
    /// Date class Start and end attributes
    /// </summary>
    public class DatesPeriod
    {
        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }
    }
}
