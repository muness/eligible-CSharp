using Newtonsoft.Json;

namespace EligibleService.Model.Claim
{
    public class MedicareCrossoverInfo
    {
        [JsonProperty("auto_send_to_secondary")]
        public bool? AutoSendToSecondary { get; set; }
    }
}
