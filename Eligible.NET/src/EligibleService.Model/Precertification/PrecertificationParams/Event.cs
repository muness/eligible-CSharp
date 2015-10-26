using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.Precert
{

    public class Event
    {

        [JsonProperty("service_type_code")]
        public string ServiceTypeCode { get; set; }

        [JsonProperty("place_of_service")]
        public string PlaceOfService { get; set; }

        [JsonProperty("level_of_service")]
        public string LevelOfService { get; set; }

        [JsonProperty("diagnosis")]
        public Collection<Diagnosi> Diagnosis { get; set; }

        [JsonProperty("delivery")]
        public Delivery Delivery { get; set; }

        [JsonProperty("from_date")]
        public string FromDate { get; set; }

        [JsonProperty("to_date")]
        public string ToDate { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("provider")]
        public Provider Provider { get; set; }
    }

}
