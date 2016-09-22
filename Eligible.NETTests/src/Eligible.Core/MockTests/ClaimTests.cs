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
                    Content = TestHelper.GetJson(TestResource.ExpectedResponse + "ClaimPayementReports.json")
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
                    Content = TestHelper.GetJson(TestResource.ExpectedResponse + "ClaimPayementReports.json")
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
                    Content = TestHelper.GetJson(TestResource.ExpectedResponse + "PaymentReports.json")
                });


            claim.ExecuteObj = restClient.Object;
            var report = claim.GetClaimPaymentReport();

            Fixture fixture = new Fixture();
            ClaimPaymentReportsResponse sut = fixture.Create<ClaimPaymentReportsResponse>();

            TestHelper.PropertiesAreEqual(sut, report.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Claim")]
        public void ClaimExceptionObjectTest()
        {
            restClient.Setup(x => x.ExecutePostPut(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Method>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.ExpectedResponse + "ClaimFailure.json")
                });


            claim.ExecuteObj = restClient.Object;

            try
            {
                var calimSuccessResponse = claim.Create(param);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.AreEqual(false, ex.EligibleError.Success);
                Assert.AreEqual("8LT5WL4UVSJ3GZ", ex.EligibleError.ReferenceId);
                Assert.AreEqual("8LT5WL4UVSJ3GZ", ex.EligibleError.EligibleId);
                Assert.AreEqual("rendering_provider_npi_invalid", ex.EligibleError.Errors[0].Code);
                Assert.AreEqual(null, ex.EligibleError.Errors[0].ExpectedValue);
                Assert.AreEqual("The rendering_provider's NPI must be exactly 10 digits", ex.EligibleError.Errors[0].Message);
                Assert.AreEqual("rendering_provider[npi]", ex.EligibleError.Errors[0].Param);
            }
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
