﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EligibleService.Core.CoreTests;
using System.Collections;
using Newtonsoft.Json;
using EligibleService.Model;
using EligibleService.Core.EnrollmentNpis;
using EligibleService.Core.Tests;
using EligibleService.NETTests;

namespace EligibleService.Core.CoreTests
{
    [TestClass]
    public class EnrollmentTests
    {
        public string EnrollmentInput { get; set; }
        Enrollment enrollment;

        [TestInitialize]
        public void Setup()
        {
            enrollment = new Enrollment();
            BaseTestClass.SetConfiguration();
            Random rnd = new Random();
            string rand = rnd.Next(1000000000, 1999999999).ToString();
            EnrollmentInput = @"{'enrollment_npi': { 'payer_id': 'NYMCR', 'endpoint': 'professional claims', 'effective_date': '2012-12-24',
	                                                 'facility_name': 'Quality', 'provider_name': 'Jane Austen', 'tax_id': '12345678',
	                                                 'address': '125 Snow Shoe Road', 'city': 'Sacramento', 'state': 'CA', 'zip': '94107',
                                                     'ptan': '54321', 'medicaid_id': '22222'," + "'npi':" + rand + @", 'authorized_signer': {
                                                     'title': 'title', 'first_name': 'Lorem', 'last_name': 'Ipsum',
                                                     'contact_number': '1478963250', 'email': 'provider@eligibleapi.com', 'signature': {
                                                     'coordinates': [{ 'lx': 47, 'ly': 9, 'mx': 47, 'my': 8 }, 
                                                     { 'lx': 46, 'ly': 8, 'mx': 47, 'my': 9 }]}}}}";
        }

        [TestMethod]
        [TestCategory("Enrollment")]
        public void EnrollmentCreationWithHashParam()
        {
            Hashtable input = JsonConvert.DeserializeObject<Hashtable>(EnrollmentInput);
            EnrollmentNpisResponse actualResponse = enrollment.Create(input);

            EnrollmentCreationSuccessCheck(actualResponse.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Enrollment")]
        public void EnrollmentCreationWithJsonParams()
        {
            EnrollmentNpisResponse actualResponse = enrollment.Create(EnrollmentInput);

            EnrollmentCreationSuccessCheck(actualResponse.JsonResponse());
        }

        private static void EnrollmentCreationSuccessCheck(string jsonResponse)
        {
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "EnrollmentSuccess.json");

            TestHelper.CompareProperties(expectedResponse, jsonResponse);

            EnrollmentNpisResponse expectedObj = JsonConvert.DeserializeObject<EnrollmentNpisResponse>(expectedResponse);
            EnrollmentNpisResponse actualObj = JsonConvert.DeserializeObject<EnrollmentNpisResponse>(jsonResponse);
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("Enrollment")]
        public void GetEnrollmentByIdTest()
        {
            EnrollmentNpisResponse actualResponse = enrollment.GetByEnrollmentNpiId("557604291");
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "EnrollmentById.json");

            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            EnrollmentNpisResponse expectedObj = JsonConvert.DeserializeObject<EnrollmentNpisResponse>(expectedResponse);
            EnrollmentNpisResponse actualObj = JsonConvert.DeserializeObject<EnrollmentNpisResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("Enrollment")]
        public void GetAllEnrollmentsTest()
        {
            EnrollmentNpisResponses actualResponse = enrollment.GetAll();

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "AllEnrollments.json");

            TestHelper.CompareProperties(expectedResponse, JsonConvert.SerializeObject(actualResponse));
        }
    }
}
