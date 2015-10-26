using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Claim
{
    public class Provider : Name
    {
        [JsonProperty("npi")]
        public string Npi { get; set; }

        [JsonProperty("secondary_id_type")]
        public string SecondaryIdType { get; set; }

        [JsonProperty("secondary_id")]
        public string SecondaryId { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        
    }
}
