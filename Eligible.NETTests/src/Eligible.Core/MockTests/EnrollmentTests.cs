using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EligibleService.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EligibleService.Common;
using System.Collections;
using EligibleService.Core.EnrollmentNpis;
using RestSharp;
using EligibleService.NETTests;
using System.Net;
using Ploeh.AutoFixture;
using EligibleService.Model.EnrollmentNpis;
using EligibleService.Model;
namespace EligibleService.Core.Tests
{
    [TestClass()]
    public class EnrollmentTests
    {
        Mock<IRequestExecute> restClient;
        Hashtable param;
        EnrollmentParams paramValues;
        Enrollment enrollment;

        [TestInitialize]
        public void Setup()
        {
            enrollment = new Enrollment();
            restClient = new Mock<IRequestExecute>();
            param = new Hashtable();
            paramValues = new EnrollmentParams();
        }

        [TestMethod()]
        [TestCategory("EnrollmentMockTest")]
        public void EnrollmentCreationWithHashtableTest()
        {
            GetResponse();

            var response = enrollment.Create(param);

            PerformEnrollmentCreationTest(response.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("EnrollmentMockTest")]
        public void EnrollmentCreationWithEnrollmentParamsTest()
        {
            GetResponse();

            var response = enrollment.Create(paramValues);

            PerformEnrollmentCreationTest(response.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("EnrollmentMockTest")]
        public void EnrollmentCreationWithJsonParamsTest()
        {
            GetResponse();

            var response = enrollment.Create("{'json': 'input'}");

            PerformEnrollmentCreationTest(response.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("EnrollmentMockTest")]
        public void EnrollmentUpdateWithHashtableTest()
        {
            GetResponse();

            var response = enrollment.Update("enrollment_npi_id", param);

            PerformEnrollmentCreationTest(response.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("EnrollmentMockTest")]
        public void EnrollmentUpdateWithEnrollmentParamsTest()
        {
            GetResponse();

            var response = enrollment.Update("enrollment_npi_id", paramValues);

            PerformEnrollmentCreationTest(response.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("EnrollmentMockTest")]
        public void EnrollmentUpdateWithJsonParamsTest()
        {
            GetResponse();

            var response = enrollment.Update("enrollment_npi_id","{'json': 'input'}");

            PerformEnrollmentCreationTest(response.JsonResponse());
        }

        [TestMethod()]
        [TestCategory("EnrollmentMockTest")]
        public void GetEnrollmentByIdTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "EnrollemtCreationResponse.json")
                });

            enrollment.ExecuteObj = restClient.Object;

            var response = enrollment.GetByEnrollmentNpiId("customer_id");

            PerformEnrollmentCreationTest(response.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("EnrollmentMockTest")]
        public void GetAllEnrollments()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "EnrollmentList.json")
                });

            enrollment.ExecuteObj = restClient.Object;

            var response = enrollment.GetAll();

            Fixture fixture = new Fixture();
            EnrollmentNpisResponses sut = fixture.Create<EnrollmentNpisResponses>();

            TestHelper.PropertiesAreEqual(sut, response.JsonResponse());
        }

        [TestMethod()]
        [TestCategory("EnrollmentMockTest")]
        public void GetReceivedPDFTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "ReceivedPDF.json")
                });

            enrollment.ExecuteObj = restClient.Object;

            var response = enrollment.GetReceivedPdf("enrollment_npi_id");

            Fixture fixture = new Fixture();
            ReceivedPdfResponse sut = fixture.Create<ReceivedPdfResponse>();

            TestHelper.PropertiesAreEqual(sut, response.JsonResponse());
        }

        [TestMethod()]
        [TestCategory("EnrollmentMockTest")]
        public void CreateOriginalSignaturePDFTest()
        {
            restClient.Setup(x => x.ExecutePdf(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Method>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "OriginalSignaturePDF.json")
                });

            enrollment.ExecuteObj = restClient.Object;
            var response = enrollment.CreateOriginalSignaturePdf("enrollment_npi_id", "signature_pdf_path");

            Fixture fixture = new Fixture();
            OriginalSignaturePdfResponse sut = fixture.Create<OriginalSignaturePdfResponse>();

            TestHelper.PropertiesAreEqual(sut, response.JsonResponse());
        }

        [TestMethod()]
        [TestCategory("EnrollmentMockTest")]
        public void UpdateOriginalSignaturePDFTest()
        {
            restClient.Setup(x => x.ExecutePdf(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Method>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "OriginalSignaturePDF.json")
                });

            enrollment.ExecuteObj = restClient.Object;
            var response = enrollment.UpdateOriginalSignaturePdf("enrollment_npi_id", "signature_pdf_path");

            Fixture fixture = new Fixture();
            OriginalSignaturePdfResponse sut = fixture.Create<OriginalSignaturePdfResponse>();

            TestHelper.PropertiesAreEqual(sut, response.JsonResponse());
        }

        [TestMethod()]
        [TestCategory("EnrollmentMockTest")]
        public void GetOriginalSignaturePDFTest()
        {
            restClient.Setup(x => x.ExecutePdf(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Method>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "OriginalSignaturePDF.json")
                });

            enrollment.ExecuteObj = restClient.Object;
            var response = enrollment.GetOriginalSignaturePdf("enrollment_npi_id");

            Fixture fixture = new Fixture();
            OriginalSignaturePdfResponse sut = fixture.Create<OriginalSignaturePdfResponse>();

            TestHelper.PropertiesAreEqual(sut, response.JsonResponse());
        }

        [TestMethod()]
        [TestCategory("EnrollmentMockTest")]
        public void DeleteOriginalSignaturePDFTest()
        {
            restClient.Setup(x => x.ExecutePdf(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Method>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "DeleteOriginalSignature.json")
                });

            enrollment.ExecuteObj = restClient.Object;
            var response = enrollment.DeleteOriginalSignaturePdf("enrollment_npi_id");

            Fixture fixture = new Fixture();
            OriginalSignaturePdfDeleteResponse sut = fixture.Create<OriginalSignaturePdfDeleteResponse>();

            TestHelper.PropertiesAreEqual(sut, response.JsonResponse());
        }

        private void GetResponse()
        {
            restClient.Setup(x => x.ExecutePostPut(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Method>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "EnrollemtCreationResponse.json")
                });

            enrollment.ExecuteObj = restClient.Object;
        }

        private static void PerformEnrollmentCreationTest(string jsonResponse)
        {
            Fixture fixture = new Fixture();
            EnrollmentNpisResponse sut = fixture.Create<EnrollmentNpisResponse>();

            TestHelper.PropertiesAreEqual(sut, jsonResponse);
        }
    }
}
