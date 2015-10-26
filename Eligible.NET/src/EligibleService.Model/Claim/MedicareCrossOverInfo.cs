using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Claim
{
    public class MedicareCrossoverInfo
    {
        [JsonProperty("auto_send_to_secondary")]
        public string AutoSendToSecondary { get; set; }
    }
}
