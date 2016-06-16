using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using EligibleService.Model;
using EligibleService.Core.Tests;
using EligibleService.NETTests;
using Newtonsoft.Json;

namespace EligibleService.Core.CoreTests
{
    [TestClass]
    public class CostEstimatesTests
    {
        CostEstimates costEstimates;
        [TestInitialize]
        public void Setup()
        {
            BaseTestClass.SetConfiguration();
            costEstimates = new CostEstimates();
        }

        [TestMethod]
        [TestCategory("CostEstimate")]
        public void CostEstimatesTest()
        {
            CostEstimatesResponse actualResponse = costEstimates.Get(CostEstimatesParams());

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "CostEstimates.json");
            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            CostEstimatesResponse expectedObj = JsonConvert.DeserializeObject<CostEstimatesResponse>(expectedResponse);
            CostEstimatesResponse actualObj = JsonConvert.DeserializeObject<CostEstimatesResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("CostEstimate")]
        [ExpectedException(typeof(EligibleService.Exceptions.EligibleException))]
        public void CostEstimatesEligibleExceptionTest()
        {
            Hashtable input = new Hashtable();

            CostEstimatesResponse actualResponse = costEstimates.Get(input);
        }

        [TestMethod]
        [TestCategory("CostEstimate")]
        [ExpectedException(typeof(EligibleService.Exceptions.AuthenticationException))]
        public void CostEstimatesAuthenticationExceptionTest()
        {
            Eligible eligible = Eligible.Instance;
            eligible.ApiKey = "invalid key";
            eligible.IsTest = true;

            CostEstimatesResponse actualResponse = costEstimates.Get(CostEstimatesParams());
        }

        private Hashtable CostEstimatesParams()
        {
            Hashtable param = new Hashtable();
            param.Add("provider_price", "1500.50");
            param.Add("network", "IN");
            param.Add("payer_id", "00001");
            param.Add("provider_last_name", "Doe");
            param.Add("provider_first_name", "John");
            param.Add("provider_npi", "0123456789");
            param.Add("member_id", "cost_estimates_001");
            param.Add("member_first_name", "IDA");
            param.Add("member_last_name", "FRANKLIN");
            param.Add("member_dob", "1701-12-12");
            param.Add("service_type", "1");

            return param;
        }
    }
}
