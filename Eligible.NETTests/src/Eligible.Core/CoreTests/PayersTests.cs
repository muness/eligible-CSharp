using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EligibleService.Core.CoreTests;
using System.Collections.ObjectModel;
using EligibleService.Model;
using EligibleService.Core;
using EligibleService.Core.Tests;
using Newtonsoft.Json;
using EligibleService.NETTests;

namespace EligibleService.Core.CoreTests
{
    [TestClass]
    public class PayersTests
    {
        Payers payers;
        [TestInitialize]
        public void Setup()
        {
            payers = new Payers();
            BaseTestClass.SetConfiguration();
        }

        [TestMethod]
        [TestCategory("Payers")]
        public void GetAllPayersTest()
        {
            PayersResponse actualPayers = payers.All();
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "PayersList.json");
            TestHelper.CompareProperties(expectedResponse, actualPayers.JsonResponse());
        }
        [TestMethod]
        [TestCategory("Payers")]
        public void GetAllPayersWithCoverageEndPointTest()
        {
            PayersResponse actualPayers = payers.All("coverage");
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "PayersWithCoverageEndPoint.json");
            TestHelper.CompareProperties(expectedResponse, actualPayers.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Payers")]
        public void GetAllPayersWithEnrollmentRequiredTest()
        {
            PayersResponse actualPayers = payers.All("", "true");
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "PayersWithEnrollmentRequired.json");
            TestHelper.CompareProperties(expectedResponse, actualPayers.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Payers")]
        public void GetAllPayersWithEndPointAndEnrollmentRequiredTest()
        {
            PayersResponse actualPayers = payers.All("coverage", "false");
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "PayersWithEndpointAndEnrollment.json");
            TestHelper.CompareProperties(expectedResponse, actualPayers.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Payers")]
        public void GetPayerByIdTest()
        {
            PayerResponse actualPayers = payers.GetById("62308");
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "Payer.json");
            TestHelper.CompareProperties(expectedResponse, actualPayers.JsonResponse());

            PayerResponse expectedObj = JsonConvert.DeserializeObject<PayerResponse>(expectedResponse);
            PayerResponse actualObj = JsonConvert.DeserializeObject<PayerResponse>(actualPayers.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("Payers")]
        public void SearchOptionsTest()
        {
            var actualPayers = payers.SearchOptions();
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "SearchOptions.json");
            TestHelper.CompareProperties(expectedResponse, actualPayers.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Payers")]
        public void SearchOptionsByPayerIdTest()
        {
            PayerSearchOptionResponse actualPayers = payers.SearchOptions("62308");
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "SearchOptionsByPayerId.json");
            TestHelper.CompareProperties(expectedResponse, actualPayers.JsonResponse());

            PayerSearchOptionResponse expectedObj = JsonConvert.DeserializeObject<PayerSearchOptionResponse>(expectedResponse);
            PayerSearchOptionResponse actualObj = JsonConvert.DeserializeObject<PayerSearchOptionResponse>(actualPayers.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("Payers")]
        public void PayersStatussesTest()
        {
            StatusResponse actualPayers = payers.Statusses();
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "PayersStatus.json");
            TestHelper.CompareProperties(expectedResponse, actualPayers.JsonResponse());

            PropertyTypesCheck(expectedResponse, actualPayers.JsonResponse());
        }

        private static void PropertyTypesCheck(string expectedResponse, string actualResponse)
        {
            StatusResponse expectedObj = JsonConvert.DeserializeObject<StatusResponse>(expectedResponse);
            StatusResponse actualObj = JsonConvert.DeserializeObject<StatusResponse>(actualResponse);
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }
        
        [TestMethod]
        [TestCategory("Payers")]
        public void PayersStatussesWithTransactionTypeTest()
        {
            StatusResponse response = payers.Statusses("835");
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "PayersStatus.json");
            TestHelper.CompareProperties(expectedResponse, response.JsonResponse());

            PropertyTypesCheck(expectedResponse, response.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Payers")]
        public void StatussesByPayerTest()
        {
            StatusResponse response = payers.StatussesByPayer("00002");
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "StatussesByPayer.json");
            TestHelper.CompareProperties(expectedResponse, response.JsonResponse());

            PropertyTypesCheck(expectedResponse,response.JsonResponse());
        }
    }
}
