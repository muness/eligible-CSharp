using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model
{
    /// <summary>
    /// Payer searchOptions model
    /// </summary>
    public class PayerSearchOptionResponse : PayerSearchOptions
    {
        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }
    }

    public class PayerSearchOptions : JsonResponseClass
    {
        [JsonProperty("payer_id")]
        public string PayerId { get; set; }

        [JsonProperty("search_options")]
        public Collection<Collection<string>> SearchOptions { get; set; }
    }

    public class PayersSearchOptionResponse : JsonResponseClass
    {
        public Collection<PayerSearchOptions> SearchOptionsList { get; set; }
    }
}
