using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Medicare
{
    /// <summary>
    /// Basic Common details for Medicare
    /// </summary>
    public class BasicDetails
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("payer_name")]
        public string PayerName { get; set; }

        [JsonProperty("policy_number")]
        public string PolicyNumber { get; set; }

        [JsonProperty("effective_date")]
        public string EffectiveDate { get; set; }

        [JsonProperty("termination_date")]
        public string TerminationDate { get; set; }

        [JsonProperty("contacts")]
        public Collection<Contact> Contacts { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
