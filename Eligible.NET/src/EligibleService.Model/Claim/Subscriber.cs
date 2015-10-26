using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EligibleService.Model.Claim
{
    public class Subscriber : Person
    {
        /// <summary>
        /// Required To Create a Claim
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Required To Create a Claim
        /// </summary>
        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        /// <summary>
        /// Required To Create a Claim
        /// </summary>
       [JsonProperty("group_name")]
        public string GroupName { get; set; }

        /// <summary>
        /// Required To Create a Claim
        /// </summary>
        [JsonProperty("dob")]
        public string Dob { get; set; }

        /// <summary>
        /// Required To Create a Claim
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("deceased_date")]
        public string DeceasedDate { get; set; }

        [JsonProperty("ssn")]
        public string Ssn { get; set; }

        [JsonProperty("pregnant")]
        public string Pregnant { get; set; }

        [JsonProperty("relationship")]
        public string Relationship { get; set; }

        [JsonProperty("insurance_type_code")]
        public string InsuranceTypeCode { get; set; }
        
    }
}
