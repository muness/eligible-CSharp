using Newtonsoft.Json;

namespace EligibleService.Model.EnrollmentNpis
{
    public class Coordinate
    {
        [JsonProperty("lx")]
        public int? LX { get; set; }

        [JsonProperty("ly")]
        public int? LY { get; set; }

        [JsonProperty("mx")]
        public int? MX { get; set; }

        [JsonProperty("my")]
        public int? MY { get; set; }
    }

}
