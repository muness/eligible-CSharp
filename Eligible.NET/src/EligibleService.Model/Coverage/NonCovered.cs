using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class NonCovered
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("type_label")]
        public string TypeLabel { get; set; }

        [JsonProperty("time_period")]
        public string TimePeriod { get; set; }

        [JsonProperty("time_period_label")]
        public string TimePeriodLabel { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("pos")]
        public string Pos { get; set; }

        [JsonProperty("pos_label")]
        public string PosLabel { get; set; }

        [JsonProperty("authorization_required")]
        public bool? AuthorizationRequired { get; set; }

        [JsonProperty("contact_details")]
        public Collection<ContactDetail> ContactDetails { get; set; }

        [JsonProperty("dates")]
        public Collection<Dates> Dates { get; set; }

        [JsonProperty("comments")]
        public Collection<String> Comments { get; set; }
    }
}
