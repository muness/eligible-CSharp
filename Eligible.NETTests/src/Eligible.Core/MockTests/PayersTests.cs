using EligibleService.Common;
using EligibleService.Core.Tests.Helpers;
using EligibleService.Model;
using EligibleService.NETTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using EligibleService.Core;
using Ploeh.AutoFixture;
using EligibleService.Model.Payer;
using System.Collections.ObjectModel;

namespace EligibleService.Core.Tests
{
    [TestClass()]
    public class PayersTests
    {
        Mock<IRequestExecute> restClient;
        Hashtable param;

        Payers payers;
        [TestInitialize]
        public void Setup()
        {
            payers = new Payers();
            restClient = new Mock<IRequestExecute>();
            param = new Hashtable();
        }

        [TestMethod()]
        [TestCategory("PayersMockTest")]
        public void GetAllPayersTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "payers.json")
                });

            payers.ExecuteObj = restClient.Object;

            var payersResponse = payers.All();

            Assert.IsNotNull(payersResponse);
            Assert.AreEqual(3, payersResponse.Payers.Count);

        }

        [TestMethod()]
        [TestCategory("PayersMockTest")]
        public void PayersResponseCheckTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "payers.json")
                });

            payers.ExecuteObj = restClient.Object;

            var payersResponse = payers.All();

            Fixture fixture = new Fixture();
            Collection<PayerResponse> sut = fixture.Create<Collection<PayerResponse>>();

            TestHelper.PropertiesAreEqual(sut, payersResponse.JsonResponse());
        }

        [TestMethod]
        [TestCategory("PayersMockTest")]
        public void PayersParamsDesirializationTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Payer.json")
                });

            payers.ExecuteObj = restClient.Object;

            PayerResponse payer = payers.GetById("00001");
            PayerResponse expectedPayer = PayerExpectedResults.GetExpectedPayer();

            TestHelper.PropertyValuesAreEquals(payer, expectedPayer);
        }

        [TestMethod()]
        [TestCategory("PayersMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void PayerDeserializationExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = ""
                });

            payers.ExecuteObj = restClient.Object;

            var payersResponse = payers.All("","false");

            Assert.IsNull(payers);
        }

        [TestMethod()]
        [TestCategory("PayersMockTest")]
        public void SearchOptionsTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "SearchOptions.json")
                });

            payers.ExecuteObj = restClient.Object;

            PayersSearchOptionResponse searchOptions = payers.SearchOptions();

            Collection<PayerSearchOptionResponse> expectedSearchOptions = SearchOptionsExpectedResults.GetExpectedSearchOption();

            Assert.IsNotNull(searchOptions);
            Assert.AreEqual(expectedSearchOptions.Count, searchOptions.SearchOptionsList.Count);
            Assert.AreEqual(expectedSearchOptions[0].PayerId, searchOptions.SearchOptionsList[0].PayerId);
            Assert.AreEqual(expectedSearchOptions[0].SearchOptions.Count, searchOptions.SearchOptionsList[0].SearchOptions.Count);      
        }

        [TestMethod()]
        [TestCategory("PayersMockTest")]
        public void SearchOptionsByPayerIdTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "SearchOptionsPayer.json")
                });

            payers.ExecuteObj = restClient.Object;

            PayerSearchOptionResponse searchOptions = payers.SearchOptions("00001");
            Assert.IsNotNull(searchOptions);
            Assert.AreEqual(6, searchOptions.SearchOptions.Count());
            Assert.AreEqual("00001", searchOptions.PayerId);
        }

        [TestMethod()]
        [TestCategory("PayersMockTest")]
        public void StatussesTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "PayerStatus.json")
                });

            payers.ExecuteObj = restClient.Object;

            StatusResponse statusses = payers.Statusses();
            StatusResponse expectedStatusses = PayerSuccessExpectedResults.GetExpectePayersStatusses();

            TestHelper.PropertyValuesAreEquals(statusses, expectedStatusses);
        }

        [TestMethod()]
        [TestCategory("PayersMockTest")]
        public void StatussesByPayerIdTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "PayerstatusById.json")
                });

            payers.ExecuteObj = restClient.Object;

            StatusResponse statusses = payers.StatussesByPayer("00002");
            StatusResponse expectedStatusses = PayerSuccessExpectedResults.GetExpectePayersStatussesById();

            TestHelper.PropertyValuesAreEquals(statusses, expectedStatusses);
        }

        [TestMethod]
        [TestCategory("PayersMockTest")]
        public void StatussesByPayerStatusTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "UnavailableStatusses.json")
                });

            payers.ExecuteObj = restClient.Object;

            StatusResponse statusses = payers.GetPayersByStatus("unavailable");
            StatusResponse expectedStatusses = PayerSuccessExpectedResults.GetExpectePayersStatussesByStatus();

            TestHelper.PropertyValuesAreEquals(statusses, expectedStatusses);
        }

        [TestMethod]
        [TestCategory("PayersMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void PayersErrorExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = "",
                    ErrorException = new WebException()
                });
            payers.ExecuteObj = restClient.Object;
            payers.All();
        }

        [TestMethod]
        [TestCategory("PayersMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void PayersExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "MedicareError.json")
                });
            payers.ExecuteObj = restClient.Object;

            payers.All();
        }

        [TestMethod]
        [TestCategory("PayersMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void PayersInvalidRequestTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = ""
                });
            payers.ExecuteObj = restClient.Object;

            payers.All();
        }

        [TestMethod]
        [TestCategory("PayersMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.AuthenticationException))]
        public void PayersApiKeyExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = ""
                });
            payers.ExecuteObj = restClient.Object;

            payers.All();

        }
      }
}
