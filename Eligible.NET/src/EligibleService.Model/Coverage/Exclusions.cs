using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class Exclusions
    {
        [JsonProperty("noncovered")]
        public Collection<NonCovered> Noncovered { get; set; }

        [JsonProperty("pre_existing_condition")]
        public PreexistingCondition PreexistingCondition { get; set; }
    }
}
