using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Claim
{
    public class Dependent : Person
    {
        /// <summary>
        /// Required To Create a Claim.
        /// date of birth of dependent in YYYY-MM-DD format ex: "dob": "1734-05-04"
        /// </summary>
        [JsonProperty("dob")]
        public string Dob { get; set; }

        /// <summary>
        /// Required To Create a Claim.
        /// gender of dependent which should be same on file with payer. Valid values are "M" and "F". ex: "gender": "F"
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Situational To Create a Claim.
        /// Relationship of patient with subscriber. Possible values are "01" (spouse), "19" (child) and "20" (employee), ex: "relationship": "01"
        /// </summary>
        [JsonProperty("relationship")]
        public string Relationship { get; set; }

        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        [JsonProperty("group_name")]
        public string GroupName { get; set; }
    }
}
