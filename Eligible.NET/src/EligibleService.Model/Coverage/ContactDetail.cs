using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    /// <summary>
    /// Coverage Contacrt Details model
    /// </summary>
    public class ContactDetail
    {
        [JsonProperty("entity_code")]
        public string EntityCode { get; set; }

        [JsonProperty("entity_code_label")]
        public string EntityCodeLabel { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("identification_type")]
        public string IdentificationType { get; set; }

        [JsonProperty("identification_code")]
        public string IdentificationCode { get; set; }

        [JsonProperty("contacts")]
        public Collection<Contact> Contacts{ get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
