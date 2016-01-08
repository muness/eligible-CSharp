using EligibleService.Model.Medicare;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace EligibleService.Model
{
    /// <summary>
    /// CMS Medicare Coverage structure
    /// </summary>
   
   [ComVisible(true)]
    public class MedicareResponse : JsonResponseClass
    {
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("member_id")]
        public string MemberId { get; set; }

        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        [JsonProperty("group_name")]
        public string GroupName { get; set; }

        [JsonProperty("dob")]
        public string Dob { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("payer_name")]
        public string PayerName { get; set; }

        [JsonProperty("payer_id")]
        public string PayerId { get; set; }

        [JsonProperty("plan_number")]
        public string PlanNumber { get; set; }

        [JsonProperty("eligibilty_dates")]
        public DatesPeriod EligibiltyDates { get; set; }

        [JsonProperty("inactivity_dates")]
        public DatesPeriod InactivityDates { get; set; }

        [JsonProperty("plan_types")]
        public PlanType PlanTypes { get; set; }

        [JsonProperty("plan_details")]
        public PlanDetails PlanDetails { get; set; }

        [JsonProperty("requested_service_types")]
        public Collection<MedicareService> RequestedServiceTypes { get; set; }

        [JsonProperty("requested_procedure_codes")]
        public Collection<ProcedureCodes> RequestedProcedureCodes { get; set; }
    }
}
