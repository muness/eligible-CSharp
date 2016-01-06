using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Claim
{
    public class Claim
    {
        /// <summary>
        /// Required For Creating a Claim.
        /// Possible values are "Y" (yes signature is on file) or "I" (informend concent) and default value is "I", ex: "patient_signature_on_file": "Y"
        /// </summary>
        [JsonProperty("patient_signature_on_file")]
        public string PatientSignatureOnFile { get; set; }

        /// <summary>
        /// Required For Creating a Claim.
        /// Possible values are "Y" (yes patient has okayed provider to be paid direct by insurance company) or "N" (no) or "W"(Not applicable) and default value is "N". ex: "direct_payment_authorized": "Y"
        /// </summary>
        [JsonProperty("direct_payment_authorized")]
        public string DirectPaymentAuthorized { get; set; }

        /// <summary>
        /// Required For Creating a Claim.
        /// Possible values are "1" (first claim ever submitted) or "7" (replacement to a previous claim) or "8" (cancellation of the claim,) ex: "frequency": "1"
        /// </summary>
        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        /// <summary>
        /// Optional For Creating a Claim.
        /// Prior authorization number. ex: "prior_authorization_number": "1234212343UHGT"
        /// </summary>
        [JsonProperty("prior_authorization_number")]
        public string PriorAuthorizationNumber { get; set; }

        /// <summary>
        /// Required For Creating a Claim.
        /// Indicates whether the provider accepts assignment. Possible values are "A"(Assigned) or "B"(Assignment accepted on Clinical lab service only) or "C"(Not assigned), ex: "accept_assignment_code": "C"
        /// </summary>
        [JsonProperty("accept_assignment_code")]
        public string AcceptAssignmentCode { get; set; }

        /// <summary>
        /// Required For Creating a Claim.
        /// The sum of all service line charges that make up this claim. ex: "total_charge": 234
        /// </summary>
       [JsonProperty("total_charge")]
        public string TotalCharge { get; set; }

        /// <summary>
        /// Optional For Clreating a Claim.
        /// Required when patient has made payment specifically toward this claim. ex: "patient_amount_paid": 24
        /// </summary>
        [JsonProperty("patient_amount_paid")]
        public string PatientAmountPaid { get; set; }

        /// <summary>
        /// Required For Clreating a Claim.
        /// Provider certifies that the statements on the reverse apply to this bill and are made a part thereof. Possible values are "Y" (yes) or "N"(no) and default value is "N".
        /// </summary>
        [JsonProperty("provider_signature_on_file")]
        public string ProviderSignatureOnFile { get; set; }

        /// <summary>
        /// Required For Clreating a Claim.
        /// Diagnosis codes. ex: "diagnosis_codes": ["309.24","390.0"]
        /// </summary>
        [JsonProperty("diagnosis_codes")]
        public Collection<string> DiagnosisCodes { get; set; }

        /// <summary>
        /// Its an array objects, where each element is a service performed under this claim.
        /// </summary>
        [JsonProperty("service_lines")]
        public Collection<ServiceLine> ServiceLines { get; set; }

        /// <summary>
        /// Optional For Creating a Claim
        /// Icd indicator to differentiate the diagnosis codes. Possible values are "10" and "9". "10" stands for icd 10 codes and "9" stands for icd 9 codes. If field is blank, diagnosis codes will be considered to indicate icd 9 codes.
        /// </summary>
        [JsonProperty("icd_indicator")]
        public string IcdIndicator { get; set; }

        [JsonProperty("service_start")]
        public string ServiceStart { get; set; }

        [JsonProperty("related_to_employment")]
        public string RelatedToEmployment { get; set; }

        [JsonProperty("auto_accident")]
        public string AutoAccident { get; set; }

        [JsonProperty("auto_accident_state")]
        public string AutoAccidentState { get; set; }

        [JsonProperty("other_accident")]
        public string OtherAccident { get; set; }

        [JsonProperty("locally_required_data")]
        public string LocallyRequiredData { get; set; }

        [JsonProperty("place_of_service")]
        public string PlaceOfService { get; set; }

        [JsonProperty("other_health_benefit_plan")]
        public string OtherHealthBenefitPlan { get; set; }

        [JsonProperty("date_of_onset_current_illness")]
        public string DateOfOnsetCurrentIllness { get; set; }

        [JsonProperty("last_worked_date")]
        public string LastWorkedDate { get; set; }

        [JsonProperty("work_return_date")]
        public string WorkReturnDate { get; set; }

        [JsonProperty("date_of_initial_treatment")]
        public string DateOfInitialTreatment { get; set; }

        [JsonProperty("last_seen_date")]
        public string LastSeenDate { get; set; }

        [JsonProperty("accident_date")]
        public string AccidentDate { get; set; }

        [JsonProperty("last_xray_date")]
        public string LastXrayDate { get; set; }

        [JsonProperty("spinal_manipulation_condition")]
        public string SpinalManipulationCondition { get; set; }

        [JsonProperty("hearing_vision_prescription_date")]
        public string HearingVisionPrescriptionDate { get; set; }

        [JsonProperty("disability_start")]
        public string DisabilityStart { get; set; }

        [JsonProperty("disability_end")]
        public string DisabilityEnd { get; set; }

        [JsonProperty("last_menstrual_date")]
        public string LastMenstrualDate { get; set; }

        [JsonProperty("acute_manifestation_date")]
        public string AcuteManifestationDate { get; set; }

        [JsonProperty("admission_date")]
        public string AdmissionDate { get; set; }

        [JsonProperty("discharge_date")]
        public string DischargeDate { get; set; }

        [JsonProperty("assumed_and_relinguished_care_start")]
        public string AssumedAndRelinguishedCareStart { get; set; }

        [JsonProperty("assumed_and_relinguished_care_end")]
        public string AssumedAndRelinguishedCareEnd { get; set; }

        [JsonProperty("repricer_received")]
        public string RepricerReceived { get; set; }

        [JsonProperty("note_code")]
        public string NoteCode { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("resubmission")]
        public string Resubmission { get; set; }

        [JsonProperty("payer_control_number")]
        public string PayerControlNumber { get; set; }

        [JsonProperty("mammography_certification_number")]
        public string MammographyCertificationNumber { get; set; }

        [JsonProperty("authorization_exception_code")]
        public string AuthorizationExceptionCode { get; set; }

        [JsonProperty("property_casualty_claim_number")]
        public string PropertyCasualtyClaimNumber { get; set; }

        [JsonProperty("clia_number")]
        public string CliaNumber { get; set; }

        [JsonProperty("homebound_indicator")]
        public string HomeboundIndicator { get; set; }

        [JsonProperty("epsdt_referral_given")]
        public string EpsdtReferralGiven { get; set; }

        [JsonProperty("epsdt_referral_condition")]
        public string EpsdtReferralCondition { get; set; }

        [JsonProperty("referral_number")]
        public string ReferralNumber { get; set; }

        [JsonProperty("special_program_code")]
        public string SpecialProgramCode { get; set; }

        [JsonProperty("anesthesiology_procedure_code")]
        public string AnesthesiologyProcedureCode { get; set; }

        [JsonProperty("service_facility")]
        public ServiceFacility ServiceFacility { get; set; }


        [JsonProperty("supplemental_information")]
        public SupplementalInformation SupplementalInformation { get; set; }

        [JsonProperty("ambulance")]
        public Ambulance Ambulance { get; set; }

        [JsonProperty("medical_record_number")]
        public string MedicalRecordNumber { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("patient_status_code")]
        public string PatientStatusCode { get; set; }

        [JsonProperty("release_of_information")]
        public string ReleaseOfInformation { get; set; }

        [JsonProperty("document_control_number")]
        public string DocumentControlNumber { get; set; }

        [JsonProperty("statement_from")]
        public string StatementFrom { get; set; }

        [JsonProperty("statement_through")]
        public string StatementThrough { get; set; }

        [JsonProperty("admission")]
        public Admission Admission { get; set; }

        [JsonProperty("principal_diagnosis_code")]
        public string PrincipalDiagnosisCode { get; set; }

        [JsonProperty("other_diagnosis_codes")]
        public Collection<string> OtherDiagnosisCodes { get; set; }

        [JsonProperty("tooth")]
        public Tooth Tooth { get; set; }

        [JsonProperty("patient_reasons_for_visit")]
        public Collection<string> PatientReasonsForVisit { get; set; }

        [JsonProperty("external_cause_of_injury")]
        public Collection<string> ExternalCauseOfInjury { get; set; }

        [JsonProperty("principle_procedure")]
        public Principleprocedure Principleprocedure { get; set; }

        [JsonProperty("other_procedures")]
        public Collection<string> OtherProcedures { get; set; }

        [JsonProperty("condition_codes")]
        public Collection<string> ConditionCodes { get; set; }

        [JsonProperty("occurrence")]
        public Collection<string> Occurrence { get; set; }

        [JsonProperty("OccurrenceSpan")]
        public Collection<string> OccurrenceSpan { get; set; }

        [JsonProperty("value_codes")]
        public Collection<ValueCodes> ValueCodes { get; set; }
    }
}
