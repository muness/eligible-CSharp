using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Claim
{
    public class Tooth
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("status_code")]
        public string StatusCode { get; set; }
    }
}
