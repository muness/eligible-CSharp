using Newtonsoft.Json;
using System;

namespace EligibleService.Model.EnrollmentNpis
{
    public class PdfResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("download_url")]
        public Uri DownloadUrl { get; set; }
    }
}
