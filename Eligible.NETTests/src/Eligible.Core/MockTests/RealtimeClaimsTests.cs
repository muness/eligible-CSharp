using Microsoft.VisualStudio.TestTools.UnitTesting;
using EligibleService.Common;
using Moq;
using System.Collections;
using EligibleService.Claim.RealtimeClaimParams;
using RestSharp;
using System.Net;
using EligibleService.NETTests;
using Ploeh.AutoFixture;
using EligibleService.Model;

namespace EligibleService.Core.Tests
{
    [TestClass()]
    public class RealtimeClaimsTests
    {
        Mock<IRequestExecute> restClient;
        Hashtable param;
        RealtimeClaimsParams paramValues;
        RealtimeClaims realtimeClaims;
        [TestInitialize]
        public void Setup()
        {
            realtimeClaims = new RealtimeClaims();
            restClient = new Mock<IRequestExecute>();
            param = new Hashtable();
            paramValues = new RealtimeClaimsParams();
        }

        [TestMethod()]
        [TestCategory("Realtime Claim Creation")]
        public void RealtimeClaimsWithJsonParamsTest()
        {
            restClient.Setup(x => x.ExecutePostPut(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Method>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "RealtimeClaimResponse.json")
                });

            realtimeClaims.ExecuteObj = restClient.Object;

            var calimSuccessResponse = realtimeClaims.Create("{json: 'json input'}");

            PerformRealtimeClaimCreationTest(calimSuccessResponse.JsonResponse());

        }

        private static void PerformRealtimeClaimCreationTest(string jsonResponse)
        {
            Fixture fixture = new Fixture();
            RealtimeClaimsResponse sut = fixture.Create<RealtimeClaimsResponse>();

            TestHelper.PropertiesAreEqual(sut, jsonResponse);
        }
    }
}
