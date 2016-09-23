using EligibleService.Core.Tests;
using EligibleService.Model;
using EligibleService.NETTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace EligibleService.Core.CoreTests
{
    [TestClass]
    public class EligibleTestIdsTests
    {
        Coverage coverage;
        [TestInitialize]
        public void Setup()
        {
            coverage = new Coverage();
            BaseTestClass.SetConfiguration();
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void CoverageEnrollmentRequiredTest()
        {
            var coverageParams = GetCoverageDependentParams();
            coverageParams["member_id"] = "U44441234";

            try
            {
                coverage.All(coverageParams);
            }
            catch(EligibleService.Exceptions.EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("Y", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("Yes", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("41", ex.EligibleError.Error.RejectReasonCode);
                Assert.AreEqual("Authorization/Access Restrictions", ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("Your NPI should be enrolled with payer id 00431 before start making eligibility queries. Please enroll using enrollment rest apis documented at https://eligibleapi.com/rest#enrollments", ex.EligibleError.Error.Details);
                Assert.AreEqual(0, ex.EligibleError.KnownIssues.Count);
                Assert.AreEqual("C", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Please Correct and Resubmit", ex.EligibleError.Error.FollowUpActionDescription);
            }
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void CoverageDuplicateEligibilityTest()
        {
            var coverageParams = GetCoverageDependentParams();
            coverageParams["member_id"] = "94532189A";

            try
            {
                coverage.All(coverageParams);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("Y", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("Yes", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("E3", ex.EligibleError.Error.RejectReasonCode);
                Assert.AreEqual("Requested Record Will Not Be Sent", ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("Duplicate eligibility requests using the same NPI/HICN combination are not allowed in the same 24 hour period. Please try again after 24 hours.", ex.EligibleError.Error.Details);
                Assert.AreEqual("N", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Resubmission Not Allowed", ex.EligibleError.Error.FollowUpActionDescription);
                Assert.AreEqual(0, ex.EligibleError.KnownIssues.Count);
            }
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void CoverageInsuredNotFoundTest()
        {
            var coverageParams = GetCoverageDependentParams();
            coverageParams["member_id"] = "U12121212";

            try
            {
                coverage.All(coverageParams);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("N", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("No", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("75", ex.EligibleError.Error.RejectReasonCode);
                Assert.AreEqual("Subscriber/Insured Not Found", ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("C", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Please Correct and Resubmit", ex.EligibleError.Error.FollowUpActionDescription);
                Assert.AreEqual("", ex.EligibleError.Error.Details);
                Assert.AreEqual(0, ex.EligibleError.KnownIssues.Count);
            }
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void CoverageInvalidSubscriberIDTest()
        {
            var coverageParams = GetCoverageDependentParams();
            coverageParams["member_id"] = "U1212ERR72";

            try
            {
                coverage.All(coverageParams);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("N", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("No", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("72", ex.EligibleError.Error.RejectReasonCode);
                Assert.AreEqual("Invalid/Missing Subscriber/Insured ID", ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("C", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Please Correct and Resubmit", ex.EligibleError.Error.FollowUpActionDescription);
                Assert.AreEqual("", ex.EligibleError.Error.Details);
                Assert.AreEqual(0, ex.EligibleError.KnownIssues.Count);
            }
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void CoverageInactivePlanTest()
        {
            var coverageParams = GetCoverageDependentParams();
            coverageParams["member_id"] = "U0INACTIVE";
            
            var coverageResponse = coverage.All(coverageParams);
            Assert.AreEqual("Inactive", coverageResponse.Plan.CoverageStatusLabel);
            Assert.AreEqual("6", coverageResponse.Plan.CoverageStatus);
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void CoverageSeparateDatesTest()
        {
            var coverageParams = GetCoverageDependentParams();
            coverageParams["member_id"] = "SEPARATE_DATES_001";

            var coverageResponse = coverage.All(coverageParams);
            Assert.AreEqual("plan_begin", coverageResponse.Plan.Dates[0].DateType);
            Assert.AreEqual("2014-12-01", coverageResponse.Plan.Dates[0].DateValue);
            Assert.AreEqual("subscriber", coverageResponse.Plan.Dates[0].DateSource);

            Assert.AreEqual("plan_end", coverageResponse.Plan.Dates[1].DateType);
            Assert.AreEqual("2015-10-31", coverageResponse.Plan.Dates[1].DateValue);
            Assert.AreEqual("subscriber", coverageResponse.Plan.Dates[1].DateSource);

            Assert.AreEqual("plan_begin", coverageResponse.Plan.Dates[2].DateType);
            Assert.AreEqual("2014-12-01", coverageResponse.Plan.Dates[2].DateValue);
            Assert.AreEqual("dependent", coverageResponse.Plan.Dates[2].DateSource);

            Assert.AreEqual("plan_end", coverageResponse.Plan.Dates[3].DateType);
            Assert.AreEqual("2014-12-31", coverageResponse.Plan.Dates[3].DateValue);
            Assert.AreEqual("dependent", coverageResponse.Plan.Dates[3].DateSource);
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void MedicareEnrollmentRequiredTest()
        {
            var coverageParams = GetCoverageDependentParams();
            coverageParams["member_id"] = "U44441234";

            try
            {
                coverage.Medicare(coverageParams);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("Y", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("Yes", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("41", ex.EligibleError.Error.RejectReasonCode);
                Assert.AreEqual("Authorization/Access Restrictions", ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("Your NPI should be enrolled with payer id 00431 before start making eligibility queries. Please enroll using enrollment rest apis documented at https://eligibleapi.com/rest#enrollments", ex.EligibleError.Error.Details);
                Assert.AreEqual(0, ex.EligibleError.KnownIssues.Count);
                Assert.AreEqual("C", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Please Correct and Resubmit", ex.EligibleError.Error.FollowUpActionDescription);
            }
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void MedicareDuplicateEligibilityTest()
        {
            var coverageParams = GetCoverageDependentParams();
            coverageParams["member_id"] = "94532189A";

            try
            {
                coverage.Medicare(coverageParams);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("Y", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("Yes", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("E3", ex.EligibleError.Error.RejectReasonCode);
                Assert.AreEqual("Requested Record Will Not Be Sent", ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("Duplicate eligibility requests using the same NPI/HICN combination are not allowed in the same 24 hour period. Please try again after 24 hours.", ex.EligibleError.Error.Details);
                Assert.AreEqual("N", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Resubmission Not Allowed", ex.EligibleError.Error.FollowUpActionDescription);
                Assert.AreEqual(0, ex.EligibleError.KnownIssues.Count);
            }
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void CostEstimateProviderPriseNotFoundTest()
        {
            CostEstimates costEstimates = new CostEstimates();
            var costEstimateParams = GetCoverageDependentParams();
            costEstimateParams["member_id"] = "ERROR_034";
            costEstimateParams["service_type"] = "4";
            costEstimateParams["network"] = "IN";

            try
            {
                costEstimates.Get(costEstimateParams);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("invalid_request_error", ex.EligibleError.Errors[0].Code);
                Assert.AreEqual("provider_price should be present and should be a valid price", ex.EligibleError.Errors[0].Message);
                Assert.AreEqual(null, ex.EligibleError.Errors[0].ExpectedValue);
                Assert.AreEqual("provider_price", ex.EligibleError.Errors[0].Param);
                Assert.AreEqual(null, ex.EligibleError.Errors[0].Path);
                Assert.AreEqual(false, ex.EligibleError.Success);
            }
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void CostEstimateNoCoverageTest()
        {
            CostEstimates costEstimates = new CostEstimates() ;
            var costEstimateParams = GetCoverageDependentParams();
            costEstimateParams["member_id"] = "ERROR_034";
            costEstimateParams["service_type"] = "4";
            costEstimateParams["network"] = "IN";
            costEstimateParams["provider_price"] = "99.00";

            try
            {
                costEstimates.Get(costEstimateParams);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("api_error", ex.EligibleError.Errors[0].Code);
                Assert.AreEqual("The payer did not return coverage information for the service type requested.", ex.EligibleError.Errors[0].Message);
                Assert.AreEqual(null, ex.EligibleError.Errors[0].ExpectedValue);
                Assert.AreEqual(null, ex.EligibleError.Errors[0].Param);
                Assert.AreEqual(null, ex.EligibleError.Errors[0].Path);
                Assert.AreEqual(false, ex.EligibleError.Success);
            }
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void PaymentReportClaimPaidTest()
        {
            Claim claim = new Claim();

            try
            {
                var paymentReport = claim.GetClaimPaymentReport("8IZ9JZXRXAIINI");
                Assert.IsNotNull(paymentReport);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("api_error", ex.EligibleError.Errors[0].Code);
                Assert.AreEqual("The payer did not return coverage information for the service type requested.", ex.EligibleError.Errors[0].Message);
                Assert.AreEqual(null, ex.EligibleError.Errors[0].ExpectedValue);
                Assert.AreEqual(null, ex.EligibleError.Errors[0].Param);
                Assert.AreEqual(null, ex.EligibleError.Errors[0].Path);
                Assert.AreEqual(false, ex.EligibleError.Success);
            }
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void PaymentStatusExceptionTest()
        {
            var paymentStatus = new PaymentStatus();
            Hashtable input = PaymentStatusParams();
            input["member_id"] = "11111111";
            try
            {
                var actualResponse = paymentStatus.Get(input);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("Y", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("Yes", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual("", ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual("", ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("A4", ex.EligibleError.Error.RejectReasonCode);
                Assert.AreEqual("Acknowledgement/Not Found-The claim/encounter can not be found in the adjudication system.", ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("C", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Please Correct and Resubmit", ex.EligibleError.Error.FollowUpActionDescription);
                Assert.AreEqual("Cannot provide further status electronically.", ex.EligibleError.Error.Details);
                Assert.AreEqual(0, ex.EligibleError.KnownIssues.Count);
            }
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void PaymentStatusNoPaymentErrorTest()
        {
            var paymentStatus = new PaymentStatus();
            Hashtable input = PaymentStatusParams();
            input["member_id"] = "10101010";
            var actualResponse = paymentStatus.Get(input);
            Assert.AreEqual("F4", actualResponse.Claims[0].Statuses[0].Codes[0].CategoryCode);
            Assert.AreEqual("104", actualResponse.Claims[0].Statuses[0].Codes[0].StatusCode);
            string expexted = "Processed according to plan provisions " + 
                              "(Plan refers to provisions that exist between the Health Plan and the Consumer or Patient)";
            Assert.AreEqual(expexted, actualResponse.Claims[0].Statuses[0].Codes[0].StatusLabel);
            Assert.AreEqual(null, actualResponse.Claims[0].Statuses[0].Codes[0].EntityCode);
            Assert.AreEqual(null, actualResponse.Claims[0].Statuses[0].Codes[0].EntityLabel);
            expexted = "Finalized/Adjudication Complete - No payment forthcoming-" + 
                       "The claim/encounter has been adjudicated and no further payment is forthcoming.";
            Assert.AreEqual(expexted, actualResponse.Claims[0].Statuses[0].Codes[0].CategoryLabel);

            expexted = "Health Care Financing Administration Common Procedural Coding System (HCPCS) Codes. " +
                                "HCFA coding scheme to group procedure(s) performed on an outpatient basis for payment to hospital under Medicare; "+
                                "primarily used for ambulatory surgical and other diagnostic departments";
            Assert.AreEqual(expexted, actualResponse.Claims[0].ServiceLines[0].ProcedureQualifierLabel);
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void PaymentStatusMoreInfoRequiredTest()
        {
            var paymentStatus = new PaymentStatus();
            Hashtable input = PaymentStatusParams();
            input["member_id"] = "12121212";
            var actualResponse = paymentStatus.Get(input);
            Assert.AreEqual("more info required", actualResponse.Claims[0].Statuses[0].AdjudicationStatus);
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void PaymentStatusPaidTest()
        {
            var paymentStatus = new PaymentStatus();
            Hashtable input = PaymentStatusParams();
            input["member_id"] = "12312312";
            var actualResponse = paymentStatus.Get(input);
            Assert.AreEqual("completed", actualResponse.Claims[0].Statuses[0].AdjudicationStatus);
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void PaymentStatusPendingTest()
        {
            var paymentStatus = new PaymentStatus();
            Hashtable input = PaymentStatusParams();
            input["member_id"] = "34343434";
            var actualResponse = paymentStatus.Get(input);
            Assert.AreEqual("pending", actualResponse.Claims[0].Statuses[0].AdjudicationStatus);
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void PaymentStatusDeniedTest()
        {
            var paymentStatus = new PaymentStatus();
            Hashtable input = PaymentStatusParams();
            input["member_id"] = "45454545";
            var actualResponse = paymentStatus.Get(input);
            Assert.AreEqual("Finalized/Denial-The claim/line has been denied.", actualResponse.Claims[0].Statuses[0].Codes[0].CategoryLabel);
            Assert.AreEqual("Denied Charge or Non-covered Charge", actualResponse.Claims[0].Statuses[0].Codes[0].StatusLabel);
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void PaymentStatusDataSearchUnsuccessfulTest()
        {
            var paymentStatus = new PaymentStatus();
            Hashtable input = PaymentStatusParams();
            input["member_id"] = "56565656";
            try
            {
                var actualResponse = paymentStatus.Get(input);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("Y", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("Yes", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual("", ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual("", ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("D0", ex.EligibleError.Error.RejectReasonCode);
                string expected = "Data Search Unsuccessful - The payer is unable to return status on the requested claim(s) "
                                  + "based on the submitted search criteria.";
                Assert.AreEqual(expected, ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("C", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Please Correct and Resubmit", ex.EligibleError.Error.FollowUpActionDescription);
                Assert.AreEqual("Subscriber and subscriber id not found.", ex.EligibleError.Error.Details);
                Assert.AreEqual(0, ex.EligibleError.KnownIssues.Count);
            }
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void PaymentStatusCorrectionRequiredTest()
        {
            var paymentStatus = new PaymentStatus();
            Hashtable input = PaymentStatusParams();
            input["member_id"] = "78787878";
            try
            {
                var actualResponse = paymentStatus.Get(input);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("Y", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("Yes", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual("", ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual("", ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("E3", ex.EligibleError.Error.RejectReasonCode);
                Assert.AreEqual("Correction required - relational fields in error.", ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("C", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Please Correct and Resubmit", ex.EligibleError.Error.FollowUpActionDescription);
                string expected = "Missing or invalid information. Note: "
                                  + "At least one other status code is required to identify the missing or invalid information.";
                Assert.AreEqual(expected, ex.EligibleError.Error.Details);
                Assert.AreEqual(0, ex.EligibleError.KnownIssues.Count);
            }
        }

        [TestMethod]
        [TestCategory("EligibleTestIDS")]
        public void PaymentStatusInformationHolderNotRespondingTest()
        {
            var paymentStatus = new PaymentStatus();
            Hashtable input = PaymentStatusParams();
            input["member_id"] = "89898989";
            try
            {
                var actualResponse = paymentStatus.Get(input);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("Y", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("Yes", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual("", ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual("", ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("E2", ex.EligibleError.Error.RejectReasonCode);
                Assert.AreEqual("Information Holder is not responding: resubmit at a later time.", ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("C", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Please Correct and Resubmit", ex.EligibleError.Error.FollowUpActionDescription);
                Assert.AreEqual("Cannot provide further status electronically.", ex.EligibleError.Error.Details);
                Assert.AreEqual(0, ex.EligibleError.KnownIssues.Count);
            }
        }


        private Hashtable GetCoverageDependentParams()
        {
            Hashtable param = new Hashtable();
            param.Add("payer_id", "00001");
            param.Add("provider_last_name", "Doe");
            param.Add("provider_first_name", "John");
            param.Add("provider_npi", "0123456789");
            param.Add("member_id", "AETNA00DEP_ACPOSII");
            param.Add("member_first_name", "IDA");
            param.Add("member_last_name", "FRANKLIN");
            param.Add("member_dob", "1701-12-12");
            param.Add("dependent_first_name", "MARK");
            param.Add("dependent_last_name", "FRANKLIN");
            param.Add("dependent_dob", "1938-01-25");
            param.Add("service_type", "30");

            return param;
        }

        private Hashtable PaymentStatusParams()
        {
            Hashtable param = new Hashtable();
            param.Add("provider_npi", "0123456789");
            param.Add("provider_tax_id", "111223333");
            param.Add("payer_id", "00001");
            param.Add("provider_last_name", "Doe");
            param.Add("provider_first_name", "John");
            param.Add("member_first_name", "IDA");
            param.Add("member_last_name", "FRANKLIN");
            param.Add("member_dob", "1701-12-12");
            param.Add("service_type", "1");
            param.Add("payer_control_number", "123123123");
            param.Add("charge_amount", "125.00");
            param.Add("start_date", "2010-06-15");
            param.Add("end_date", "2010-06-15");
            param.Add("trace_number", "BHUYTOK98IK");

            return param;
        }
    }
}
