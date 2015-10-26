using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Claim
{
    public class PayToPlan
    {
        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }

        [JsonProperty("secondary_id")]
        public string SecondaryId { get; set; }

        [JsonProperty("secondary_id_type")]
        public string SecondaryIdType { get; set; }

        [JsonProperty("tin")]
        public string Tin { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }


    }
}
