using EligibleService.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.Precert
{
    public class PrecertParams : BasicParams
    {
        [JsonProperty("payer")]
        public PrecertPayer Payer { get; set; }

        [JsonProperty("requester")]
        public Requester Requester { get; set; }

        [JsonProperty("subscriber")]
        public PrecertSubscriber Subscriber { get; set; }

        [JsonProperty("dependent")]
        public PrecertDependent Dependent { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }

        [JsonProperty("services")]
        public Collection<PrecertService> Services { get; set; }
    }

}
