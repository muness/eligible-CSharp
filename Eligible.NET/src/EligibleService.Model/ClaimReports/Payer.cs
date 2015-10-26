using EligibleService.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.ClaimReports
{
    public class ReportsPayer
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("contacts")]
        public Collection<Contact> Contacts { get; set; }

        [JsonProperty("crossover_payer")]
        public CrossoverPayer CrossoverPayer { get; set; }

        [JsonProperty("corrected_priority_payer")]
        public CrossoverPayer CorrectedPriorityPayer { get; set; }
    }

}
