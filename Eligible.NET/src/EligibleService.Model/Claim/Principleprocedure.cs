using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Claim
{
    public class Principleprocedure
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
