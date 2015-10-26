using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EligibleService.Model
{
    /// <summary>
    /// Payer searchOptions model
    /// </summary>
    public class PayerSearchOptionResponse : JsonResponseClass
    {
        [JsonProperty("payer_id")]
        public string PayerId { get; set; }

        [JsonProperty("search_options")]
        public Collection<Collection<string>> SearchOptions { get; set; }
    }

    public class PayersSearchOptionResponse : JsonResponseClass
    {
        public Collection<PayerSearchOptionResponse> SearchOptionsList { get; set; }
    }
}
