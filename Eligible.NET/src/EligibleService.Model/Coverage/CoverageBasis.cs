using Newtonsoft.Json;
using System.Collections.Generic;

namespace EligibleService.Model.Coverage
{
    public class CoverageBasis
    {
        [JsonProperty("_")]
        [JsonIgnore]
        public string NullValue { get; set; }

        [JsonProperty("comments")]
        public List<string> Comments { get; set; }
    }
}
