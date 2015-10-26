using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EligibleService.Model.Claim;
using EligibleService.Model;

namespace EligibleService.Claim.RealtimeClaimParams
{

    public class RealtimeClaimsParams : BasicParams
    {

        [JsonProperty("estimation")]
        public string Estimation { get; set; }

        [JsonProperty("billing_provider")]
        public BillingProvider BillingProvider { get; set; }

        [JsonProperty("payer")]
        public Payer Payer { get; set; }

        [JsonProperty("subscriber")]
        public Subscriber Subscriber { get; set; }

        [JsonProperty("dependent")]
        public Dependent Dependent { get; set; }

        [JsonProperty("claim")]
        public Claim Claim { get; set; }
    }

}
