using Newtonsoft.Json;
using System;

namespace EligibleService.Model.Coverage
{
    /// <summary>
    /// Coverage Demographics
    /// </summary>
    public class Demographics
    {
        [JsonProperty("subscriber")]
        public Demographic Subscriber { get; set; }

        [JsonProperty("dependent")]
        public Dependent Dependent { get; set; }
    }
}
