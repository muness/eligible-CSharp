using EligibleService.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.RealtimeClaims
{
    public class RealPayer
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public object Id { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("contacts")]
        public Collection<Contact> Contacts { get; set; }
    }

}
