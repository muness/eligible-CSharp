using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.PaymentStatus
{
    public class PayementPayer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("contacts")]
        public Collection<Contact> Contacts { get; set; }
    }

}
