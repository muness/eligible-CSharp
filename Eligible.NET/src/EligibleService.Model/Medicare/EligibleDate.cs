using Newtonsoft.Json;
using System;

namespace EligibleService.Model.Medicare
{
    /// <summary>
    /// Eligible Date format
    /// </summary>
    public class EligibleDate
    {
        [JsonProperty("professional")]
        public string Professional { get; set; }

        [JsonProperty("technical")]
        public string Technical { get; set; }
    }
}
