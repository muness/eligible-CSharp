using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.EnrollmentNpis
{
    public class Signature
    {
        [JsonProperty("coordinates")]
        public Collection<Coordinate> Coordinates { get; set; }
    }

}
