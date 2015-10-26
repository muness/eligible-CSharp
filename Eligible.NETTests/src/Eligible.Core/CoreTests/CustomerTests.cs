using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections;
using EligibleService.Model;
using EligibleService.Core.Tests;
using EligibleService.NETTests;
using EligibleService.Model.Customer;

namespace EligibleService.Core.CoreTests
{
    [TestClass]
    public class CustomerTests
    {
        public string CustomerInput { get; set; }
        Customer customer;

        [TestInitialize]
        public void Setup()
        {
            BaseTestClass.SetConfiguration();
            customer = new Customer();
            CustomerInput = "{ 'customer': { 'name': 'ABC company', 'site_name': 'ABC site name' } }";
        }
        [TestMethod]
        [TestCategory("Customer")]
        public void CustomerCreationWithHashParam()
        {
            Hashtable input = JsonConvert.DeserializeObject<Hashtable>(CustomerInput);

            CustomerResponse actualResponse = customer.Create(input);

            CustomerCreationSuccessCheck(actualResponse.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Customer")]
        public void CustomerCreationWithCustomerParams()
        {
            CustomerParams input = JsonConvert.DeserializeObject<CustomerParams>(CustomerInput);
            CustomerResponse actualResponse = customer.Create(input);

            CustomerCreationSuccessCheck(actualResponse.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Customer")]
        public void CustomerCreationWithJsonParams()
        {
            CustomerResponse actualResponse = customer.Create(CustomerInput);

            CustomerCreationSuccessCheck(actualResponse.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Customer")]
        public void CustomerCreationTest()
        {
            CustomerResponse actualResponse = customer.Create("ABC company", "ABC site name");

            CustomerCreationSuccessCheck(actualResponse.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Customer")]
        public void CustomerUpdateWithHashParam()
        {
            Hashtable input = JsonConvert.DeserializeObject<Hashtable>(CustomerInput);
            CustomerResponse actualResponse = customer.Update("TN344YY67HH09KK", input);

            CustomerCreationSuccessCheck(actualResponse.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Customer")]
        public void CustomerUpdateWithCustomerParams()
        {
            CustomerParams input = JsonConvert.DeserializeObject<CustomerParams>(CustomerInput);
            CustomerResponse actualResponse = customer.Update("TN344YY67HH09KK", input);

            CustomerCreationSuccessCheck(actualResponse.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Customer")]
        public void CustomerUpdateWithJsonParams()
        {
            CustomerResponse actualResponse = customer.Update("TN344YY67HH09KK", CustomerInput);

            CustomerCreationSuccessCheck(actualResponse.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Customer")]
        public void CustomerUpdateTest()
        {
            CustomerResponse actualResponse = customer.Update("TN344YY67HH09KK", "ABC company", "ABC site name");

            CustomerCreationSuccessCheck(actualResponse.JsonResponse());
        }

        private static void CustomerCreationSuccessCheck(string jsonResponse)
        {
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "CustomerSuccess.json");

            TestHelper.CompareProperties(expectedResponse, jsonResponse);

            CustomerResponse expectedObj = JsonConvert.DeserializeObject<CustomerResponse>(expectedResponse);
            CustomerResponse actualObj = JsonConvert.DeserializeObject<CustomerResponse>(jsonResponse);
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("Customer")]
        public void GetCustomerByIdTest()
        {
            CustomerResponse actualResponse = customer.GetByCustomerId("TN344YY67HH09KK");

            CustomerCreationSuccessCheck(actualResponse.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Customer")]
        public void GetAllCustomersTest()
        {
            CustomersResponse actualResponse = customer.GetAll();

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "AllCustomers.json");

            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            CustomersResponse expectedObj = JsonConvert.DeserializeObject<CustomersResponse>(expectedResponse);
            CustomersResponse actualObj = JsonConvert.DeserializeObject<CustomersResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }
    }
}
