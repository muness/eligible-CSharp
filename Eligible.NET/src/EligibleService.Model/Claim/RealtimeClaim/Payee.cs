using EligibleService.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.RealtimeClaims
{
    public class Payee
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("npi")]
        public string Npi { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("additional_ids")]
        public Collection<Detail> AdditionalIds { get; set; }
    }

}
