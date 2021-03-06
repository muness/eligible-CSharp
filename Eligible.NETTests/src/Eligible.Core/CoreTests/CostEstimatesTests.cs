﻿using System;
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
        public void CostEstimatesDependentTest()
        {
            Hashtable costestimateParamas = CostEstimatesParams();
            costestimateParamas["member_id"] = "cost_estimates_002";
            costestimateParamas["service_type"] = "48";
            CostEstimatesResponse actualResponse = costEstimates.Get(costestimateParamas);

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "CostEstimateDependent.json");
            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            CostEstimatesResponse expectedObj = JsonConvert.DeserializeObject<CostEstimatesResponse>(expectedResponse);
            CostEstimatesResponse actualObj = JsonConvert.DeserializeObject<CostEstimatesResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("CostEstimate")]
        public void CostEstimatesMultipleSTCTest()
        {
            Hashtable costestimateParamas = CostEstimatesParams();
            costestimateParamas["member_id"] = "cost_estimates_004";
            costestimateParamas["service_type"] = "4,5,98";
            CostEstimatesResponse actualResponse = costEstimates.Get(costestimateParamas);

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "CostEstimatesMultipleSTC.json");
            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            CostEstimatesResponse expectedObj = JsonConvert.DeserializeObject<CostEstimatesResponse>(expectedResponse);
            CostEstimatesResponse actualObj = JsonConvert.DeserializeObject<CostEstimatesResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("CostEstimate")]
        public void CostEstimatesMultipleCoinsuranceTest()
        {
            Hashtable costestimateParamas = CostEstimatesParams();
            costestimateParamas["member_id"] = "cost_estimates_005";
            costestimateParamas["service_type"] = "48,98";
            CostEstimatesResponse actualResponse = costEstimates.Get(costestimateParamas);

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "CostEstimatesMultipleCoinsurance.json");
            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            CostEstimatesResponse expectedObj = JsonConvert.DeserializeObject<CostEstimatesResponse>(expectedResponse);
            CostEstimatesResponse actualObj = JsonConvert.DeserializeObject<CostEstimatesResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("CostEstimate")]
        public void CostEstimatesAuthorizationRequiredWarningTest()
        {
            Hashtable costestimateParamas = CostEstimatesParams();
            costestimateParamas["member_id"] = "cost_estimates_007";
            costestimateParamas["service_type"] = "51";
            CostEstimatesResponse actualResponse = costEstimates.Get(costestimateParamas);

            Assert.AreEqual("authorization_required", actualResponse.Warnings[0].Code);
            Assert.AreEqual("The payer has indicated that this service requires prior authorization in order to be covered. This cost estimation is provided assuming prior authorization has been granted, but you may wish to verify this with the payer.", actualResponse.Warnings[0].Message);
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
            param.Add("service_type", "98");

            return param;
        }
    }
}
