using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using EligibleService.Core.Tests;
using System.IO;
using EligibleService.NETTests;
using Newtonsoft.Json;
using EligibleService.Model.Coverage;
using EligibleService.Model.Medicare;
using EligibleService.Model;

namespace EligibleService.Core.CoreTests
{
    [TestClass]
    public class CoverageTests
    {
        Coverage coverage;
        [TestInitialize]
        public void Setup()
        {
            coverage = new Coverage();
            BaseTestClass.SetConfiguration();
        }
        [TestMethod]
        [TestCategory("Coverage")]
        public void RetrieveCoverageForSubscriberTest()
        {
            CoverageResponse response = coverage.All(GetCoverageSubsciberParams());
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "CoverageSubscriber.json");
            TestHelper.CompareProperties(expectedResponse, response.JsonResponse());

            CoverageResponse expectedObj = JsonConvert.DeserializeObject<CoverageResponse>(expectedResponse);
            CoverageResponse actualObj = JsonConvert.DeserializeObject<CoverageResponse>(response.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("Coverage")]
        public void RetrieveCoverageForDependentTest()
        {
            CoverageResponse response = coverage.All(GetCoverageDependentParams());
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "CoverageDependent.json");
            TestHelper.CompareProperties(expectedResponse, response.JsonResponse());

            CoverageResponse expectedObj = JsonConvert.DeserializeObject<CoverageResponse>(expectedResponse);
            CoverageResponse actualObj = JsonConvert.DeserializeObject<CoverageResponse>(response.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
            TestHelper.CompareProperties(JsonConvert.SerializeObject(expectedObj), JsonConvert.SerializeObject(actualObj));
        }

        [TestMethod]
        [TestCategory("Coverage")]
        public void ReturnOnlyDemographicsTest()
        {
            var coverageParams = GetCoverageDependentParams();
            coverageParams["return_only"] = "demographics";
            CoverageResponse response = coverage.All(coverageParams);

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "CoverageDependent.json");

            CoverageResponse expectedObj = JsonConvert.DeserializeObject<CoverageResponse>(expectedResponse);
            CoverageResponse actualObj = JsonConvert.DeserializeObject<CoverageResponse>(response.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj.Demographics, expectedObj.Demographics);
            TestHelper.CompareProperties(JsonConvert.SerializeObject(expectedObj), JsonConvert.SerializeObject(actualObj));
        }

        [TestMethod]
        [TestCategory("Coverage")]
        public void ReturnOnlyPlanTest()
        {
            var coverageParams = GetCoverageDependentParams();
            coverageParams["return_only"] = "plan";
            CoverageResponse response = coverage.All(coverageParams);

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "CoverageDependent.json");

            CoverageResponse expectedObj = JsonConvert.DeserializeObject<CoverageResponse>(expectedResponse);
            CoverageResponse actualObj = JsonConvert.DeserializeObject<CoverageResponse>(response.JsonResponse());
            TestHelper.PropertyValuesAreEquals(response.Plan, expectedObj.Plan);
            TestHelper.CompareProperties(JsonConvert.SerializeObject(expectedObj), JsonConvert.SerializeObject(actualObj));
        }

        [TestMethod]
        [TestCategory("Coverage")]
        public void ReturnOnlyInsuranceTest()
        {
            var coverageParams = GetCoverageDependentParams();
            coverageParams["return_only"] = "insurance";
            CoverageResponse response = coverage.All(coverageParams);

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "CoverageDependent.json");

            CoverageResponse expectedObj = JsonConvert.DeserializeObject<CoverageResponse>(expectedResponse);
            CoverageResponse actualObj = JsonConvert.DeserializeObject<CoverageResponse>(response.JsonResponse());
            TestHelper.PropertyValuesAreEquals(response.Insurance, expectedObj.Insurance);
            TestHelper.CompareProperties(JsonConvert.SerializeObject(expectedObj), JsonConvert.SerializeObject(actualObj));
        }

        [TestMethod]
        [TestCategory("Coverage")]
        public void ReturnOnlyFailureTest()
        {
            var coverageParams = GetCoverageDependentParams();
            coverageParams["return_only"] = "insurance";
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
                Assert.AreEqual(null, ex.EligibleError.KnownIssues);
            }
        }

        [TestMethod]
        [TestCategory("Medicare")]
        public void MedicareTest()
        {
            Hashtable medicareParams = GetCoverageSubsciberParams();
            medicareParams["member_id"] = "cost_medicare_001";
            medicareParams["service_type"] = "67";
            medicareParams["payer_id"] = "00431";

            try
            {
                MedicareResponse response = coverage.Medicare(medicareParams);
                string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "Medicare.json");
                TestHelper.CompareProperties(expectedResponse, response.JsonResponse());

                MedicareResponse expectedObj = JsonConvert.DeserializeObject<MedicareResponse>(expectedResponse);
                MedicareResponse actualObj = JsonConvert.DeserializeObject<MedicareResponse>(response.JsonResponse());
                TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
            }
            catch(EligibleService.Exceptions.EligibleException ex)
            {
                Assert.AreEqual("Duplicate eligibility requests using the same NPI/HICN combination are not allowed in the same 24 hour period. Please try again after 24 hours.", ex.EligibleError.Error.Details);
                Assert.AreEqual("Y", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("Yes", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual("", ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("E3", ex.EligibleError.Error.RejectReasonCode);
                Assert.AreEqual("Requested Record Will Not Be Sent", ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("N", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Resubmission Not Allowed", ex.EligibleError.Error.FollowUpActionDescription);
            }
        }

        [TestMethod]
        [TestCategory("Medicare")]
        public void ReturnOnlyInMedicareTest()
        {
            Hashtable medicareParams = GetCoverageSubsciberParams();
            medicareParams["member_id"] = "cost_medicare_001";
            medicareParams["service_type"] = "67";
            medicareParams["payer_id"] = "00431";
            medicareParams["return_only"] = "eligibility_dates";

            try
            {
                MedicareResponse response = coverage.Medicare(medicareParams);
                string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "Medicare.json");

                MedicareResponse expectedObj = JsonConvert.DeserializeObject<MedicareResponse>(expectedResponse);
                MedicareResponse actualObj = JsonConvert.DeserializeObject<MedicareResponse>(response.JsonResponse());
                TestHelper.PropertyValuesAreEquals(actualObj.EligibilityDates, expectedObj.EligibilityDates);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.AreEqual("Duplicate eligibility requests using the same NPI/HICN combination are not allowed in the same 24 hour period. Please try again after 24 hours.", ex.EligibleError.Error.Details);
                Assert.AreEqual("Y", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("Yes", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual("", ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("E3", ex.EligibleError.Error.RejectReasonCode);
                Assert.AreEqual("Requested Record Will Not Be Sent", ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("N", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Resubmission Not Allowed", ex.EligibleError.Error.FollowUpActionDescription);
            }
        }

        [TestMethod]
        [TestCategory("Medicare")]
        public void ReturnOnlyInMedicareFailureTest()
        {
            Hashtable medicareParams = GetCoverageSubsciberParams();
            medicareParams["member_id"] = "94532189A";
            medicareParams["service_type"] = "67";
            medicareParams["payer_id"] = "00431";
            medicareParams["return_only"] = "eligibility_dates";

            try
            {
                MedicareResponse response = coverage.Medicare(medicareParams);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.AreEqual("Duplicate eligibility requests using the same NPI/HICN combination are not allowed in the same 24 hour period. Please try again after 24 hours.", ex.EligibleError.Error.Details);
                Assert.AreEqual("Y", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("Yes", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual(null, ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("E3", ex.EligibleError.Error.RejectReasonCode);
                Assert.AreEqual("Requested Record Will Not Be Sent", ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("N", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Resubmission Not Allowed", ex.EligibleError.Error.FollowUpActionDescription);
            }
        }

        private Hashtable GetCoverageSubsciberParams()
        {
            Hashtable param = new Hashtable();
            param.Add("payer_id", "00001");
            param.Add("provider_last_name", "Doe");
            param.Add("provider_first_name", "John");
            param.Add("provider_npi", "0123456789");
            param.Add("member_id", "cost_estimates_001");
            param.Add("member_first_name", "IDA");
            param.Add("member_last_name", "FRANKLIN");
            param.Add("member_dob", "1701-12-12");
            param.Add("service_type", "30");

            return param;
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
