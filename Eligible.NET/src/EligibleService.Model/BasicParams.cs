using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model
{
    public class BasicParams
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("test")]
        public bool Test { get; set; }
    }
}
