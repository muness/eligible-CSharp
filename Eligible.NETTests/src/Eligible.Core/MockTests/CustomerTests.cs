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
using EligibleService.Model.Customer;
using RestSharp;
using System.Net;
using EligibleService.NETTests;
using Ploeh.AutoFixture;
using EligibleService.Model;
namespace EligibleService.Core.Tests
{
    [TestClass()]
    public class CustomerTests
    {
        Mock<IRequestExecute> restClient;
        Hashtable param;
        CustomerParams paramValues;
        Customer customer;
        [TestInitialize]
        public void Setup()
        {
            customer = new Customer();
            restClient = new Mock<IRequestExecute>();
            param = new Hashtable();
            paramValues = new CustomerParams();
        }

        [TestMethod()]
        [TestCategory("CustomerMockTest")]
        public void CustomerCreationWithHashtableTest()
        {
            GetResponse();

            var response = customer.Create(param);

            PerformCustomerCreationTest(response.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("CustomerMockTest")]
        public void CustomerCreationWithRequiredParams()
        {
            GetResponse();

            var response = customer.Create("Company name", "site name");

            PerformCustomerCreationTest(response.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("CustomerMockTest")]
        public void CustomerCreationWithClaimParamsTest()
        {
            GetResponse();

            var response = customer.Create(paramValues);

            PerformCustomerCreationTest(response.JsonResponse());
        }

        [TestMethod()]
        [TestCategory("CustomerMockTest")]
        public void CustomerCreationWithJsonParamsTest()
        {
            GetResponse();

            var response = customer.Create("{'json': 'input'}");

            PerformCustomerCreationTest(response.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("CustomerMockTest")]
        public void CustomerUpdateWithHashtableTest()
        {
            GetResponse();

            var response = customer.Update("customer_id", param);

            PerformCustomerCreationTest(response.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("CustomerMockTest")]
        public void CustomerUpdateWithClaimParamsTest()
        {
            GetResponse();

            var response = customer.Update("customer_id", paramValues);

            PerformCustomerCreationTest(response.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("CustomerMockTest")]
        public void CustomerUpdateWithJsonParamsTest()
        {
            GetResponse();

            var response = customer.Update("customer_id", "{'json': 'input'}");

            PerformCustomerCreationTest(response.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("CustomerMockTest")]
        public void CustomerUpdateWithRequiredParams()
        {
            GetResponse();

            var response = customer.Update("customer_id","Company name", "site name");

            PerformCustomerCreationTest(response.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("CustomerMockTest")]
        public void GetCustomerByIdTest()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "CustomerResponse.json")
                });

            customer.ExecuteObj = restClient.Object;

            var calimSuccessResponse = customer.GetByCustomerId("customer_id");

            PerformCustomerCreationTest(calimSuccessResponse.JsonResponse());

        }

        [TestMethod()]
        [TestCategory("CustomerMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.AuthenticationException))]
        public void ApiUnauthorizedException()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = null
                });

            customer.ExecuteObj = restClient.Object;

            customer.GetAll();

        }

        [TestMethod()]
        [TestCategory("CustomerMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void BadRequestException()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.Ambiguous,
                    Content = null
                });

            customer.ExecuteObj = restClient.Object;

            customer.GetByCustomerId("customer_id");

        }

        [TestMethod()]
        [TestCategory("CustomerMockTest")]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void InvalidResponseException()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = string.Empty
                });

            customer.ExecuteObj = restClient.Object;

            customer.GetByCustomerId("customer_id");
        }

        [TestMethod()]
        [TestCategory("CustomerMockTest")]
        public void GetAllCustomers()
        {
            restClient.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Hashtable>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "CustomersList.json")
                });

            customer.ExecuteObj = restClient.Object;

            var customers = customer.GetAll();

            Fixture fixture = new Fixture();
            CustomersResponse sut = fixture.Create<CustomersResponse>();

            TestHelper.PropertiesAreEqual(sut, customers.JsonResponse());
        }

        private void GetResponse()
        {
            restClient.Setup(x => x.ExecutePostPut(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RequestOptions>(), It.IsAny<Method>()))
                .Returns(new RestResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = TestHelper.GetJson(TestResource.MocksPath + "CustomerResponse.json")
                });

            customer.ExecuteObj = restClient.Object;
        }

        /// <summary>
        /// Common steps to test Claim creation
        /// </summary>
        private static void PerformCustomerCreationTest(string jsonResponse)
        {
            Fixture fixture = new Fixture();
            CustomerResponse sut = fixture.Create<CustomerResponse>();

            TestHelper.PropertiesAreEqual(sut, jsonResponse);
        }
    }
}
