using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Claim
{
    public class ValueCodes
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("amount")]
        public string Smount { get; set; }
    }
}
