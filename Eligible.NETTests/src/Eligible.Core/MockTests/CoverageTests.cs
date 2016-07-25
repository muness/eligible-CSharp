using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EligibleService.Common;
using System.Collections;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using EligibleService.NETTests;
using EligibleService.Core.Tests.Helpers;
using Ploeh.AutoFixture;
using EligibleService.Model.Coverage;
using EligibleService.Model;
using EligibleService.Exceptions;
using EligibleService.Model.CostEstimates;

namespace EligibleService.Core.Tests
{
    [TestClass()]
    public class CoverageTests
    {
        Mock<IRequestExecute> restClient;
        Hashtable param;
        Coverage coverage;
        [TestInitialize]
        public void Setup()
        {
            coverage = new Coverage();
            restClient = new Mock<IRequestExecute>();
            param = new Hashtable();
        }

        [TestMethod()]
        [TestCategory("CoverageMockTest")]
        public void CoverageResponseCheckTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Coverage.json")
                });


            coverage.ExecuteObj = restClient.Object;
            var coverages = coverage.All(param);

            Assert.IsNotNull(coverages);

            Fixture fixture = new Fixture();
            var sut = fixture.Create<CoverageResponse>();

            TestHelper.PropertiesAreEqual(sut, coverages.JsonResponse());
        }

        [TestMethod()]
        [TestCategory("CoverageMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void AllCoverageNullResponseTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = null

                });


            coverage.ExecuteObj = restClient.Object;
            var coverages = coverage.All(param);

            Assert.IsNull(coverages);
        }

        [TestMethod()]
        [TestCategory("CoverageMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.AuthenticationException))]
        public void AllCoverageExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = "Could not authenticate you. Please re-try with a valid API key."

                });


            coverage.ExecuteObj = restClient.Object;
            var coverages = coverage.All(param);       
        }


        [TestMethod()]
        [TestCategory("CoverageMockTest")]
        public void DemographicDeserializationTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Coverage.json")

                });


            coverage.ExecuteObj = restClient.Object;

            var coverages = coverage.All(param);
            
            Assert.AreEqual("FRANKLIN", coverages.Demographics.Subscriber.LastName);
            Assert.AreEqual("BEN", coverages.Demographics.Subscriber.FirstName);
            Assert.AreEqual("COST_ESTIMATES_001", coverages.Demographics.Subscriber.MemberId);
            Assert.AreEqual("123123123", coverages.Demographics.Subscriber.GroupId);
            Assert.AreEqual("FREEDOM GROUP  INC.", coverages.Demographics.Subscriber.GroupName);
            Assert.AreEqual("1757-05-23", coverages.Demographics.Subscriber.Dob);
            Assert.AreEqual("M", coverages.Demographics.Subscriber.Gender);
        }


        [TestMethod()]
        [TestCategory("CoverageMockTest")]
        public void DemographicAddressDeserializationTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Coverage.json")

                });


            coverage.ExecuteObj = restClient.Object;
            var coverages = coverage.All(param);

            Assert.AreEqual("323 REASON ROAD", coverages.Demographics.Subscriber.Address.StreetLine1);
            Assert.AreEqual(null, coverages.Demographics.Subscriber.Address.StreetLine2);
            Assert.AreEqual("HILLSBORO", coverages.Demographics.Subscriber.Address.City);
            Assert.AreEqual("TX", coverages.Demographics.Subscriber.Address.State);
            Assert.AreEqual("76645", coverages.Demographics.Subscriber.Address.Zip);          
        }

        [TestMethod]
        [TestCategory("CoverageMockTest")]
        public void DemographicDependentDeserializationTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Coverage.json")

                });


            coverage.ExecuteObj = restClient.Object;

            var coverages = coverage.All(param);

            Assert.AreEqual("01", coverages.Demographics.Dependent.Relationship);
            Assert.AreEqual("MARK", coverages.Demographics.Dependent.DependentFirstName);
            Assert.AreEqual("FRANKLIN", coverages.Demographics.Dependent.DependentLastName);
            Assert.AreEqual("1938-01-25", coverages.Demographics.Dependent.DependentDob);
            Assert.AreEqual("test", coverages.Demographics.Dependent.RelationshipCode);
        }
        
        [TestMethod]
        [TestCategory("CoverageMockTest")]
        public void InsurenceDeserializationTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Coverage.json")

                });


            coverage.ExecuteObj = restClient.Object;
            var coverages = coverage.All(param);

            Assert.IsNotNull(coverages.Insurance);
            Assert.AreEqual("ELIG_SNDBX", coverages.Insurance.Id);
            Assert.AreEqual("Sandbox", coverages.Insurance.Name);
            Assert.AreEqual("PR", coverages.Insurance.PayerType);
            Assert.AreEqual("Payer", coverages.Insurance.PayerTypeLabel);
        }

        [TestMethod]
        [TestCategory("CoverageMockTest")]
        public void InsurenceServiceProvidersDeserializationTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Coverage.json")
                });


            coverage.ExecuteObj = restClient.Object;

            var coverages = coverage.All(param);
            var physician = coverages.Insurance.ServiceProviders.Physicians[0];
            Assert.IsNotNull(coverages.Insurance.ServiceProviders);
            Assert.AreEqual("L", physician.EligibilityCode);
            Assert.AreEqual("Primary Care Provider", physician.EligibilityCodeLabel);
            Assert.AreEqual("PS", physician.InsuranceType);
            Assert.AreEqual("Point of Service (POS)", physician.InsuranceTypeLabel);
            Assert.AreEqual(true, physician.PrimaryCare);
            Assert.AreEqual(false, physician.Restricted);
            Assert.AreEqual(1, physician.ContactDetails.Count());
            Assert.AreEqual("PRP", physician.ContactDetails[0].EntityCode);
            Assert.AreEqual("Primary Payer", physician.ContactDetails[0].EntityCodeLabel);
            Assert.AreEqual(null, physician.ContactDetails[0].FirstName);
            Assert.AreEqual("FRANKLIN", physician.ContactDetails[0].LastName);
            Assert.AreEqual("Member Identification Number", physician.ContactDetails[0].IdentificationType);
            Assert.AreEqual("1234567890", physician.ContactDetails[0].IdentificationCode);
            Assert.AreEqual(0, physician.Dates.Count());
            Assert.AreEqual("PCP SELECTION NOT REQUIRED", physician.Comments[0]);
        }



        [TestMethod]
        [TestCategory("CostEstimate")]
        public void PlanFinancialsServiceDeliveryParseTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Coverage.json")
                });


            coverage.ExecuteObj = restClient.Object;

            var coverageResponse = coverage.All(param);

            ServiceDelivery sd = new ServiceDelivery()
            {
                From = 1,
                To = 3,
                Period = "Years",
                Type = "Uniys"
            };

            TestHelper.PropertyValuesAreEquals(sd, coverageResponse.Plan.Financials.Deductible.Remainings.InNetwork[0].ServiceDelivery);
            TestHelper.PropertyValuesAreEquals(sd, coverageResponse.Plan.Financials.Deductible.Remainings.OutNetwork[0].ServiceDelivery);
            TestHelper.PropertyValuesAreEquals(sd, coverageResponse.Plan.Financials.Deductible.Totals.InNetwork[0].ServiceDelivery);
            TestHelper.PropertyValuesAreEquals(sd, coverageResponse.Plan.Financials.Deductible.Totals.OutNetwork[0].ServiceDelivery);
        }

        [TestMethod]
        [TestCategory("CoverageMockTest")]
        public void CoveragePlanExclusionsTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Coverage.json")
                });


            
            coverage.ExecuteObj = restClient.Object;

            CoverageResponse coverageResponse = coverage.All(param);
            Plan expectedCoverage = CoveragePlanExpectedResults.GetExpectedCoveragePlan();

            TestHelper.PropertyValuesAreEquals(coverageResponse.Plan.Exclusions, expectedCoverage.Exclusions);

        }

        [TestMethod]
        [TestCategory("CoverageMockTest")]
        public void CoveragePlanFinancialStopLossTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Coverage.json")
                });


            coverage.ExecuteObj = restClient.Object;
            CoverageResponse coverageResponse = coverage.All(param);
            Plan expectedCoverage = CoveragePlanExpectedResults.GetExpectedCoveragePlan();

            TestHelper.PropertyValuesAreEquals(coverageResponse.Plan.Financials.StopLoss, expectedCoverage.Financials.StopLoss);

        }

        [TestMethod]
        [TestCategory("CoverageMockTest")]
        public void CoveragePlanFinancialCoinsurenceTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Coverage.json")
                });


            coverage.ExecuteObj = restClient.Object;
            var coverageResponse = coverage.All(param);

            FinancialFlowsPercents expectedCoverage = CoveragePlanExpectedResults.GetCoinsurance();

            TestHelper.PropertyValuesAreEquals(coverageResponse.Plan.Financials.Coinsurance, expectedCoverage);

        }

        [TestMethod]
        [TestCategory("CoverageMockTest")]
        public void CoveragePlanFinancialCopaymentTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Coverage.json")
                });


            coverage.ExecuteObj = restClient.Object;
            var coverageResponse = coverage.All(param);
            
            FinancialFlowsAmounts expectedCoverage = CoveragePlanExpectedResults.GetCoPayment();

            TestHelper.PropertyValuesAreEquals(coverageResponse.Plan.Financials.Copayment, expectedCoverage);

        }

        [TestMethod]
        [TestCategory("CoverageMockTest")]
        public void CoveragePlanFinancialCostContainmentAndSpendDownTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Coverage.json")
                });


            coverage.ExecuteObj = restClient.Object;
            var coverageResponse = coverage.All(param);

            Financial expectedCoverage = CoveragePlanExpectedResults.GetFinancial();

            TestHelper.PropertyValuesAreEquals(coverageResponse.Plan.Financials.CostContainment, expectedCoverage);
            TestHelper.PropertyValuesAreEquals(coverageResponse.Plan.Financials.SpendDown, expectedCoverage);

        }
        [TestMethod]
        [TestCategory("CoverageMockTest")]
        public void CoverageErrorTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "MedicareError.json")
                });


            coverage.ExecuteObj = restClient.Object;
            try
            {
                coverage.All(param);
            }
            catch(EligibleException ex)
            {
                Fixture fixture = new Fixture();
                var sut = fixture.Create<CoverageErrorDetails>();

                TestHelper.PropertiesAreEqual(sut, JsonConvert.SerializeObject(ex.EligibleError));
            }
        }

        [TestMethod]
        [TestCategory("CoverageMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.EligibleException))]
        public void CoverageExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "MedicareError.json")
                });

            coverage.ExecuteObj = restClient.Object;

            var coverageResponse = coverage.All(param);
        }

        [TestMethod]
        [TestCategory("CoverageMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void CoverageInvalidRequestTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = ""
                });


            coverage.ExecuteObj = restClient.Object;

            var coverageResponse = coverage.All(param);
        }

        [TestMethod]
        [TestCategory("CoverageMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.AuthenticationException))]
        public void CoverageApiKeyExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = ""
                });


            coverage.ExecuteObj = restClient.Object;

            var coverageResponse = coverage.All(param);
        }
        [TestMethod]
        [TestCategory("MedicareMockTest")]
        public void MedicareErrorTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "MedicareError.json")
                });

            coverage.ExecuteObj = restClient.Object;
            try
            {
                coverage.Medicare(param);
            }
            catch(EligibleException ex)
            {
                Fixture fixture = new Fixture();
                var sut = fixture.Create<CoverageErrorDetails>();

                TestHelper.PropertiesAreEqual(sut, JsonConvert.SerializeObject(ex.EligibleError));
                TestHelper.PropertiesAreEqual(sut, ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("MedicareMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.EligibleException))]
        public void MedicareExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "MedicareError.json")
                });


            coverage.ExecuteObj = restClient.Object;
            
            var medicare = coverage.Medicare(param);
        }

        [TestMethod]
        [TestCategory("MedicareMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void MedicareInvalidRequestTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = ""
                });


            coverage.ExecuteObj = restClient.Object;

            var medicare = coverage.Medicare(param);
        }

        [TestMethod]
        [TestCategory("MedicareMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.AuthenticationException))]
        public void MedicareApiKeyExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = ""
                });


            coverage.ExecuteObj = restClient.Object;

            var medicare = coverage.Medicare(param);
        }

        [TestMethod()]
        [TestCategory("MedicareMockTest")]
        public void MedicareResponseCheckTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "Medicare.json")
                });


            coverage.ExecuteObj = restClient.Object;
            var medicare = coverage.Medicare(param);

            Fixture fixture = new Fixture();
            var sut = fixture.Create<MedicareResponse>();

            TestHelper.PropertiesAreEqual(sut, medicare.JsonResponse());
        }

        [TestMethod]
        [TestCategory("CoverageMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void CoverageErrorExceptionTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = "",
                    ErrorException = new WebException()
                });


            coverage.ExecuteObj = restClient.Object;
            coverage.All(param);
        }
    }
}
