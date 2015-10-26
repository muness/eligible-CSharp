using Newtonsoft.Json;
using EligibleService.Model;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.ClaimReports
{
    public class Payee
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("npi")]
        public string Npi { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("additional_ids")]
        public Collection<Detail> AdditionalIds { get; set; }

        [JsonProperty("adjustments")]
        public Collection<ProviderAdjustment> Adjustments { get; set; }

        [JsonProperty("delivery_method")]
        public RemittanceDeliverMethod DeliveryMethod { get; set; }
    }

}
