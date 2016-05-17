using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class PreexistingCondition
    {
        [JsonProperty("waiting_period")]
        public Collection<WaitingPeriod> WaitingPeriod { get; set; }
    }

    public class Period
    {
        [JsonProperty("date")]
        public DateTime? Date { get; set; }
        [JsonProperty("comments")]
        public Collection<string> Comments { get; set; }
    }

    public class WaitingPeriod
    {
        [JsonProperty(" ")]
        public Period Period { get; set; }
    }
}
