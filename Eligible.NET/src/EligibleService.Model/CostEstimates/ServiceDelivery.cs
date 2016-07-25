using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.CostEstimates
{
    public class ServiceDelivery
    {
        [JsonProperty("from")]
        public int? From { get; set; }

        [JsonProperty("to")]
        public int? To { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
