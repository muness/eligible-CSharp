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
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "CoverageSubscriber.json");
            TestHelper.CompareProperties(expectedResponse, response.JsonResponse());

            CoverageResponse expectedObj = JsonConvert.DeserializeObject<CoverageResponse>(expectedResponse);
            CoverageResponse actualObj = JsonConvert.DeserializeObject<CoverageResponse>(response.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("Medicare")]
        public void MedicareTest()
        {
            MedicareResponse response = coverage.Medicare(GetCoverageSubsciberParams());
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "Medicare.json");
            TestHelper.CompareProperties(expectedResponse, response.JsonResponse());

            MedicareResponse expectedObj = JsonConvert.DeserializeObject<MedicareResponse>(expectedResponse);
            MedicareResponse actualObj = JsonConvert.DeserializeObject<MedicareResponse>(response.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        private Hashtable GetCoverageSubsciberParams()
        {
            Hashtable param = new Hashtable();
            param.Add("payer_id", "00001");
            param.Add("provider_last_name", "Doe");
            param.Add("provider_first_name", "John");
            param.Add("provider_npi", "0123456789");
            param.Add("member_id", "AETNAS8398");
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
            param.Add("member_id", "AETNAS8398");
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
