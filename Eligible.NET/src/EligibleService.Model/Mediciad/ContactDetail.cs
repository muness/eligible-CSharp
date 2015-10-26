using Newtonsoft.Json;
using EligibleService.Model;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.Medicaid
{
    public class ContactDetail
    {
        [JsonProperty("entity_code")]
        public string EntityCode { get; set; }

        [JsonProperty("entity_code_label")]
        public string EntityCodeLabel { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("contacts")]
        public Collection<Contact> Contacts { get; set; }

        [JsonProperty("emergency_room_copay_amount")]
        public string EmergencyRoomCopayAmount { get; set; }
    }

}
