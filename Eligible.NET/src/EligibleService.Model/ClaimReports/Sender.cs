using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EligibleService.Claim.ClaimReports
{
    public class Sender : RecieverSenderBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("supplemental_code")]
        public string SupplementalCode { get; set; }
    }

}
