using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class PreexistingCondition
    {
        [JsonProperty("waiting_period")]
        public Collection<string> WaitingPeriod { get; set; }
    }
}
