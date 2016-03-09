using Newtonsoft.Json;

namespace EligibleService.Model.Medicare
{
    public class SearchOptions
    {
        [JsonProperty("used")]
        public bool? Used { get; set; }

        [JsonProperty("parameters")]
        public string Parameters { get; set; }

        [JsonProperty("combinations")]
        public int? Combinations { get; set; }
    }
}
