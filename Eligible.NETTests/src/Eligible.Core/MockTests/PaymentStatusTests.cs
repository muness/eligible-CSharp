using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EligibleService.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EligibleService.Common;
using Moq;
using System.Collections;
using RestSharp;
using System.Net;
using EligibleService.NETTests;
using Ploeh.AutoFixture;
using EligibleService.Model.PaymentStatus;
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
                Fixture fixture = new Fixture();
                var sut = fixture.Create<CoverageErrorDetails>();

                TestHelper.PropertiesAreEqual(sut, JsonConvert.SerializeObject(ex.EligibleError));
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
