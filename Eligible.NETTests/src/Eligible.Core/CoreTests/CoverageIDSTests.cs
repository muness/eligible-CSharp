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
    }
}
