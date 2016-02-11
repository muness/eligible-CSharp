using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class Insurance
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("payer_type")]
        public string PayerType { get; set; }

        [JsonProperty("payer_type_label")]
        public string PayerTypeLabel { get; set; }

        [JsonProperty("contacts")]
        public Collection<Contact> Contacts { get; set; }

        [JsonProperty("service_providers")]
        public ServiceProviders ServiceProviders { get; set; }
    }
}
