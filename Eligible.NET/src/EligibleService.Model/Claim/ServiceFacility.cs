﻿using Newtonsoft.Json;

namespace EligibleService.Model.Claim
{
    public class ServiceFacility
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("npi")]
        public string Npi { get; set; }

        [JsonProperty("secondary_id_type")]
        public string SecondaryIdType { get; set; }

        [JsonProperty("secondary_id")]
        public string SecondaryId { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

    }
}
