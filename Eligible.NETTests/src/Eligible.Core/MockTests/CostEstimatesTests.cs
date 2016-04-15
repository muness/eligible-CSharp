using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EligibleService.Common;
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
    public class CostEstimatesTests
    {
        Mock<IRequestExecute> restClient;
        Hashtable param;
        CostEstimates costEstimates;
        public CostEstimatesResponse response { get; set; }
        [TestInitialize]
        public void Setup()
        {
            costEstimates = new CostEstimates();
            restClient = new Mock<IRequestExecute>();
            param = new Hashtable();
        }

        [TestMethod()]
        [TestCategory("CostEstimateMockTest")]
        public void GetCostEstimatesTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "CostEstimate.json")
                });


            costEstimates.ExecuteObj = restClient.Object;

            var acknowledgements = costEstimates.Get(param);

            Assert.IsNotNull(acknowledgements);
        }

        [TestMethod]
        [TestCategory("CostEstimateMockTest")]
        public void CostEstimatesErrorTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "ClaimFailure.json")
                });


            costEstimates.ExecuteObj = restClient.Object;
            try
            {
                costEstimates.Get(param);
            }
            catch(EligibleException ex)
            {
                Fixture fixture = new Fixture();
                var sut = fixture.Create<EligibleGenericError>();

                TestHelper.PropertiesAreEqual(sut, JsonConvert.SerializeObject(ex.EligibleError));
            }
        }

        [TestMethod]
        [TestCategory("CostEstimateMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.EligibleException))]
        public void CostEstimatesExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "ClaimFailure.json")
                });


            costEstimates.ExecuteObj = restClient.Object;
            costEstimates.Get(param);
        }

        [TestMethod]
        [TestCategory("CostEstimateMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void CostEstimatesInvalidRequestTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = ""
                });


            costEstimates.ExecuteObj = restClient.Object;
            costEstimates.Get(param);
        }

        [TestMethod]
        [TestCategory("CostEstimateMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.AuthenticationException))]
        public void CostEstimatesApiKeyExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = ""
                });


            costEstimates.ExecuteObj = restClient.Object;
            costEstimates.Get(param);
        }
    }
}
