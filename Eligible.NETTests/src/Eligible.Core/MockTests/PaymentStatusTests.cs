using Microsoft.VisualStudio.TestTools.UnitTesting;
using EligibleService.Common;
using Moq;
using System.Collections;
using RestSharp;
using System.Net;
using EligibleService.NETTests;
using Ploeh.AutoFixture;
using EligibleService.Exceptions;
using EligibleService.Model;
using Newtonsoft.Json;

namespace EligibleService.Core.Tests
{
    [TestClass()]
    public class PaymentStatusTests
    {
        Mock<IRequestExecute> restClient;
        Hashtable param;

        PaymentStatus paymentStatus;

        [TestInitialize]
        public void Setup()
        {
            paymentStatus = new PaymentStatus();
            restClient = new Mock<IRequestExecute>();
            param = new Hashtable();
        }

        [TestMethod()]
        [TestCategory("PaymentStatusMockTest")]
        public void GetPaymentStatusTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "paymentStatus.json")
                });

            paymentStatus.ExecuteObj = restClient.Object;

            var acknowledgements = paymentStatus.Get(param);

            Fixture fixture = new Fixture();
            PayementStatusResponse sut = fixture.Create<PayementStatusResponse>();

            TestHelper.PropertiesAreEqual(sut, acknowledgements.JsonResponse());
        }

        [TestMethod]
        [TestCategory("PaymentStatusMockTest")]
        public void PaymentStatusErrorTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "MedicareError.json")
                });
            paymentStatus.ExecuteObj = restClient.Object;

            try
            {
                paymentStatus.Get(param);
            }
            catch(EligibleException ex)
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
            }
        }

        [TestMethod]
        [TestCategory("PaymentStatusMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.EligibleException))]
        public void PaymentStatusExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "MedicareError.json")
                });
            paymentStatus.ExecuteObj = restClient.Object;

            paymentStatus.Get(param);
        }

        [TestMethod]
        [TestCategory("PaymentStatusMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void PaymentStatusInvalidRequestTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = ""
                });
            paymentStatus.ExecuteObj = restClient.Object;

            paymentStatus.Get(param);
        }

        [TestMethod]
        [TestCategory("PaymentStatusMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.AuthenticationException))]
        public void PaymentStatusApiKeyExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = ""
                });
            paymentStatus.ExecuteObj = restClient.Object;

            paymentStatus.Get(param);
        }
    }
}
