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
using EligibleService.Model.Precertification;
using EligibleService.Model;
namespace EligibleService.Core.Tests
{
    [TestClass()]
    public class PrecertificationTests
    {
        Mock<IRequestExecute> restClient;
        Hashtable param;
        Precertification precertification;
        [TestInitialize]
        public void Setup()
        {
            precertification = new Precertification();
            restClient = new Mock<IRequestExecute>();
            param = new Hashtable();
        }


        [TestMethod()]
        [TestCategory("Precertification")]
        public void GetAllPrecertificationsTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "PreCertification.json")
                });

            precertification.ExecuteObj = restClient.Object;
            var response = precertification.Inquiry(param);

            Fixture fixture = new Fixture();
            var sut = fixture.Create<PrecertificationInquiryResponse>();
            TestHelper.PropertiesAreEqual(sut, response.JsonResponse());

        }
    }
}
