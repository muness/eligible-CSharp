using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EligibleService.Model.Coverage
{
    public class CoverageBasis
    {
        public string VisitsLimitation { get; set; }

        [JsonProperty("comments")]
        public List<string> Comments { get; set; }

        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            var payer_keys = _additionalData.Keys;
            string key = "";
            foreach (string payer_key in payer_keys)
            {
                if (payer_key.Contains("_"))
                {
                    key = payer_key;
                }
            }
            if (key != "")
                VisitsLimitation = _additionalData[key].ToString();
            else
                VisitsLimitation = null;
        }

        public CoverageBasis()
        {
            _additionalData = new Dictionary<string, JToken>();
        }
    }
}
