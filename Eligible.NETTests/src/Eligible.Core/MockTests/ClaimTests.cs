using Microsoft.VisualStudio.TestTools.UnitTesting;
using EligibleService.Common;
using Moq;
using System.Collections;
using RestSharp;
using System.Net;
using EligibleService.NETTests;
using EligibleService.Model.Claim;
using EligibleService.Core;
using EligibleService.Claim.ClaimReports;
using Newtonsoft.Json;
using Ploeh.AutoFixture;
using System;
using EligibleService.Model;

namespace EligibleService.Core.Tests
{
    [TestClass()]
    public class ClaimTests
    {
        Mock<IRequestExecute> restClient;
        Hashtable param;
        ClaimParams paramValues;
        Claim claim;

        [TestInitialize]
        public void Setup()
        {
            claim = new Claim();
            restClient = new Mock<IRequestExecute>();
            param = new Hashtable();
            paramValues = new ClaimParams();
        }

        [TestMethod()]
        [TestCategory("ClaimMockTest")]
        public void SubmitClaimWithHashtableTest()
        {
            restClient.Setup(x => x.ExecutePostPut(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Method>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "ClaimSuccess.json")
                });


            claim.ExecuteObj = restClient.Object;
            var calimSuccessResponse = claim.Create(param);

            PerformClaimCreationTest(calimSuccessResponse.JsonResponse());
           
        }

        [TestMethod()]
        [TestCategory("ClaimMockTest")]
        public void SubmitClaimWithClaimParamsTest()
        {
            restClient.Setup(x => x.ExecutePostPut(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Method>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "ClaimSuccess.json")
                });


            claim.ExecuteObj = restClient.Object;
            var calimSuccessResponse = claim.Create(paramValues);

            PerformClaimCreationTest(calimSuccessResponse.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("ClaimMockTest")]
        public void SubmitClaimWithJsonParamsTest()
        {
            restClient.Setup(x => x.ExecutePostPut(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Method>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "ClaimSuccess.json")
                });


            claim.ExecuteObj = restClient.Object;
            var calimSuccessResponse = claim.Create(TestHelper.GetJson(TestResource.MocksPath + "ClaimSuccess.json"));

            PerformClaimCreationTest(calimSuccessResponse.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("ClaimMockTest")]
        public void ClaimAcknowledgementsTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "ClaimAcknowledgements.json")
                });

            claim.ExecuteObj = restClient.Object;
            var acknowledgements = claim.GetClaimAcknowledgements("12121212");

            Fixture fixture = new Fixture();
            ClaimAcknowledgementsResponse sut = fixture.Create<ClaimAcknowledgementsResponse>();

            TestHelper.PropertiesAreEqual(sut, acknowledgements.JsonResponse());
        }

        [TestMethod()]
        [TestCategory("ClaimMockTest")]
        public void ClaimMutlipleAcknowledgementsTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "MultipleAcknowledgements.json")
                });


            claim.ExecuteObj = restClient.Object;
            var acknowledgements = claim.GetClaimAcknowledgements();

            Fixture fixture = new Fixture();
            MultipleAcknowledgementsResponse sut = fixture.Create<MultipleAcknowledgementsResponse>();

            TestHelper.PropertiesAreEqual(sut, acknowledgements.JsonResponse());
        }

        [TestMethod()]
        [TestCategory("ClaimMockTest")]
        public void ClaimMutlipleAcknowledgementsWithRequiredParamsTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                            .Returns(new RestResponse()
                            {
                                StatusCode = HttpStatusCode.OK,
                                Content = TestHelper.GetJson(TestResource.MocksPath + "MultipleAcknowledgements.json")
                            });


            claim.ExecuteObj = restClient.Object;
            var acknowledgements = claim.GetClaimAcknowledgements(param);

            Fixture fixture = new Fixture();
            MultipleAcknowledgementsResponse sut = fixture.Create<MultipleAcknowledgementsResponse>();
            TestHelper.PropertiesAreEqual(sut, acknowledgements.JsonResponse());
        }

        [TestMethod()]
        [TestCategory("ClaimMockTest")]
        public void GetSingleClaimPaymentReportTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "PaymentReportsPerReference.json")
                });


            claim.ExecuteObj = restClient.Object;
            var report = claim.GetClaimPaymentReport("reference_id");
           
            Fixture fixture = new Fixture();
            ClaimPaymentReportResponse sut = fixture.Create<ClaimPaymentReportResponse>();

            TestHelper.PropertiesAreEqual(sut, report.JsonResponse());
        }

        [TestMethod()]
        [TestCategory("ClaimMockTest")]
        public void GetSpecificClaimPaymentReportTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "PaymentReportsPerReference.json")
                });


            claim.ExecuteObj = restClient.Object;
            var report = claim.GetClaimPaymentReport("reference_id", "ID");

            Fixture fixture = new Fixture();
            ClaimPaymentReportResponse sut = fixture.Create<ClaimPaymentReportResponse>();

            TestHelper.PropertiesAreEqual(sut, report.JsonResponse());
        }

        [TestMethod()]
        [TestCategory("ClaimMockTest")]
        public void GetAllClaimPaymentReportTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "PaymentReports.json")
                });


            claim.ExecuteObj = restClient.Object;
            var report = claim.GetClaimPaymentReport();

            Fixture fixture = new Fixture();
            ClaimPaymentReportsResponse sut = fixture.Create<ClaimPaymentReportsResponse>();

            TestHelper.PropertiesAreEqual(sut, report.JsonResponse());
        }

        /// <summary>
        /// Common steps to test Claim creation
        /// </summary>
        private static void PerformClaimCreationTest(string claimResponse)
        {
            Fixture fixture = new Fixture();
            ClaimResponse sut = fixture.Create<ClaimResponse>();

            TestHelper.PropertiesAreEqual(sut, claimResponse);
        }
    }
}
