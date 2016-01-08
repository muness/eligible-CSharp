using Newtonsoft.Json;

namespace EligibleService.Claim.RealtimeClaims
{
    public class Amount : Quantity
    {
        [JsonProperty("patient_responsibility")]
        public int PatientResponsibility { get; set; }
    }
}
