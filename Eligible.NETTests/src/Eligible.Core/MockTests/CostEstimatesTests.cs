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
using EligibleService.Model.CostEstimates;

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
        [TestCategory("CostEstimate")]
        public void CostEstimatesServiceDeliveryPropertyTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "CostEstimatesServiceDelivery.json")
                });


            costEstimates.ExecuteObj = restClient.Object;

            var acknowledgements = costEstimates.Get(param);

            Assert.AreEqual(null, acknowledgements.CostEstimates[0].CostEstimateEquation.Coinsurance[0].ServiceDelivery);
            Assert.ReferenceEquals(acknowledgements.CostEstimates[0].CostEstimateAlternatives.Copayment[0].ServiceDelivery, new ServiceDelivery());
            Assert.AreEqual(acknowledgements.CostEstimates[0].CostEstimateAlternatives.Copayment[0].ServiceDelivery.Type, "Units");
            Assert.AreEqual(acknowledgements.CostEstimates[0].CostEstimateAlternatives.Copayment[0].ServiceDelivery.Period, "Years");
            Assert.AreEqual(acknowledgements.CostEstimates[0].CostEstimateAlternatives.Copayment[0].ServiceDelivery.To, 3);
            Assert.AreEqual(acknowledgements.CostEstimates[0].CostEstimateAlternatives.Copayment[0].ServiceDelivery.From, 1);
        }

        [TestMethod]
        [TestCategory("CostEstimate")]
        public void CostEstimateServiceDeliveryParseTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "CostEstimatesServiceDelivery.json")
                });


            costEstimates.ExecuteObj = restClient.Object;

            var acknowledgements = costEstimates.Get(param);

            ServiceDelivery sd = new ServiceDelivery()
            {
                From = 1,
                To = 3,
                Period = "Years",
                Type = "Uniys"
            };

            Assert.AreEqual(null, acknowledgements.CostEstimates[0].CostEstimateEquation.Coinsurance[0].ServiceDelivery);
            Assert.AreEqual(null, acknowledgements.CostEstimates[0].CostEstimateEquation.Copayment[0].ServiceDelivery);
            TestHelper.PropertyValuesAreEquals(sd, acknowledgements.CostEstimates[0].CostEstimateEquation.Deductible[0].ServiceDelivery);
            TestHelper.PropertyValuesAreEquals(sd, acknowledgements.CostEstimates[0].CostEstimateAlternatives.Copayment[0].ServiceDelivery);
            TestHelper.PropertyValuesAreEquals(sd, acknowledgements.CostEstimates[0].CostEstimateAlternatives.Coinsurance[0].ServiceDelivery);
            TestHelper.PropertyValuesAreEquals(sd, acknowledgements.CostEstimates[0].CostEstimateAlternatives.Deductible[0].ServiceDelivery);
        }

        [TestMethod]
        [TestCategory("CostEstimateMockTest")]
        public void CostEstimatesErrorTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "CostEstimateAdditionalPolicyWarning.json")
                });


            costEstimates.ExecuteObj = restClient.Object;
            try
            {
                costEstimates.Get(param);
            }
            catch(EligibleException ex)
            {
                Fixture fixture = new Fixture();
                var sut = fixture.Create<CostEstimateError>();

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

        [TestMethod()]
        [TestCategory("CostEstimateMockTest")]
        public void GetCostEstimatesMedicareErrorTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "CostEstimateMedicareError.json")
                });

            costEstimates.ExecuteObj = restClient.Object;
            try
            {
                var acknowledgements = costEstimates.Medicare(param);
            }
            catch(EligibleService.Exceptions.EligibleException ex)
            {
                Assert.AreEqual("UY97UCAC2QG7X", ex.EligibleError.EligibleId);
                Assert.AreEqual("6/22/2016 1:40:01 PM", ex.EligibleError.CreatedAt.ToString());
                Assert.AreEqual("api_error", ex.EligibleError.Errors[0].Code);
                Assert.AreEqual("Cannot calculate estimate for service type codes 10 because it belongs to both Medicare Part A and Medicare Part B. Support for the same service type codes covered by Part A and Part B has not been implemented.", ex.EligibleError.Errors[0].Message);
                Assert.AreEqual("service_type_code", ex.EligibleError.Errors[0].Param);
                Assert.AreEqual(null, ex.EligibleError.Errors[0].ExpectedValue);
                Assert.AreEqual(false, ex.EligibleError.Success);
            }
        }

        [TestMethod()]
        [TestCategory("CostEstimateMockTest")]
        public void GetCostEstimatesAdditionalPolicyWarningTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "CostEstimateAdditionalPolicyWarning.json")
                });


            costEstimates.ExecuteObj = restClient.Object;

            try
            {
                var acknowledgements = costEstimates.Get(param);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.AreEqual("8LIKGP596MDI41", ex.EligibleError.EligibleId);
                Assert.AreEqual("6/22/2016 1:57:23 PM", ex.EligibleError.CreatedAt.ToString());
                Assert.AreEqual("additional_policy", ex.EligibleError.Warnings[0].Code);
                Assert.AreEqual("An additional policy was found. The cost estimate can still be performed, but may not reflect true out-of-pocket expenses if the patient is covered by an additional policy.", ex.EligibleError.Warnings[0].Message);
                Assert.AreEqual(null, ex.EligibleError.Warnings[0].Param);
                Assert.AreEqual("plan.additional_insurance_policies", ex.EligibleError.Warnings[0].Path[0]);
                Assert.AreEqual(null, ex.EligibleError.Warnings[0].ExpectedValue);
                Assert.AreEqual(false, ex.EligibleError.Success);
            }
        }

        [TestMethod()]
        [TestCategory("CostEstimateMockTest")]
        public void GetCostEstimatesErrorTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "CostEstimateError.json")
                });


            costEstimates.ExecuteObj = restClient.Object;

            try
            {
                var acknowledgements = costEstimates.Get(param);
            }
            catch (EligibleService.Exceptions.EligibleException ex)
            {
                Assert.AreEqual("UY98ZFHIOYCGE", ex.EligibleError.EligibleId);
                Assert.AreEqual("6/22/2016 1:59:19 PM", ex.EligibleError.CreatedAt.ToString());
                Assert.AreEqual("invalid_request_error", ex.EligibleError.Errors[0].Code);
                Assert.AreEqual("Payer does not support Dependent Inquiries", ex.EligibleError.Errors[0].Message);
                Assert.AreEqual(null, ex.EligibleError.Errors[0].Param);
                Assert.AreEqual(null, ex.EligibleError.Errors[0].ExpectedValue);
                Assert.AreEqual(false, ex.EligibleError.Success);
            }
        }
    }
}
