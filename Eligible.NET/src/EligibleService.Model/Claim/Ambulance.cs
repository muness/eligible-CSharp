﻿using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Claim
{
    public class Ambulance
    {
        [JsonProperty("pick_up")]
        public Address Pickup { get; set; }

        [JsonProperty("drop_off")]
        public Address Dropoff { get; set; }

        [JsonProperty("transport_info")]
        public TransportInfo TransportInfo { get; set; }
    }

    public class TransportInfo
    {
        [JsonProperty("number_of_patients")]
        public int? NumberOfPatients { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("transport_reason_code")]
        public string TransportReasonCode { get; set; }

        [JsonProperty("miles_transported")]
        public string MilesTransported { get; set; }

        [JsonProperty("round_trip_reason")]
        public string RoundtripReason { get; set; }

        [JsonProperty("stretcher_reason")]
        public string StretcherReason { get; set; }

        [JsonProperty("condition_codes")]
        public Collection<string> ConditionCodes { get; set; }  
    }
}