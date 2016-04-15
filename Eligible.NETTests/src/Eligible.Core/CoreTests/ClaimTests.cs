using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Newtonsoft.Json;
using EligibleService.Model;
using EligibleService.Core.Tests;
using EligibleService.NETTests;
using EligibleService.Model.Claim;

namespace EligibleService.Core.CoreTests
{
    [TestClass]
    public class ClaimTests
    {
        public string ClaimInput { get; set; }
        Claim claim;

        [TestInitialize]
        public void Setup()
        {
            claim = new Claim();
            BaseTestClass.SetConfiguration();
            ClaimInput = "{'scrub_eligibility': 'false', 'billing_provider': {    'tax_id': '123456789',    'tax_id_type': 'EI',    'entity': 'false',    'phone_number': '1234567890',    'organization_name': 'ELIGIBLE INC',    'last_name': 'SOME',    'first_name': 'PROVIDER',    'middle_name': '',    'address': {      'street_line_1': '1842 UNION STREET',      'street_line_2': '',      'city': 'Seattle',      'state': 'WA',      'zip': '981011231'    },    'npi': '1234567893',    'taxonomy_code': '101YM0800X'  },  'payer': {    'id': '60054',    'name': 'Aetna',    'address': {      'street_line_1': '603 3rd Ave Van',      'street_line_2': '',      'city': 'San Francisco',      'state': 'CA',      'zip': '941231232'    }  },  'subscriber': {    'id': '1234567890',    'first_name': 'Benjamin',    'last_name': 'Franklin',    'middle_name': '',    'address': {      'street_line_1': '123 NW St',      'street_line_2': '',      'city': 'Seattle',      'state': 'WA',      'zip': '981171232'    },    'phone_number': '9129129121',    'group_id': '100012345',    'dob': '1974-02-06',    'gender': 'M',    'group_name': ''  },  'dependent': {    'last_name': 'Franklin',    'first_name': 'Cheryl',    'middle_name': '',    'dob': '1976-03-06',    'gender': 'F',    'address': {      'street_line_1': '123 NW St',      'street_line_2': '',      'city': 'Seattle',      'state': 'WA',      'zip': '981171232'    },    'relationship': '01',    'phone_number': '9129129123'  },  'claim': {    'patient_signature_on_file': 'Y',    'direct_payment_authorized': 'Y',    'frequency': '1',    'prior_authorization_number': '1234567890',    'accept_assignment_code': 'C',    'total_charge': '118.05',    'patient_amount_paid': '0',    'provider_signature_on_file': 'Y',    'diagnosis_codes': [      '309.24', '309.0'   ],    'service_lines': [      {        'service_date_from': '2014-05-07',        'service_date_to': '2014-05-07',        'place_of_service': '11',        'procedure_code': '90837',        'procedure_modifiers': [            'UN'        ],        'diagnosis_code_pointers': [          '1'        ],        'charge_amount': '118.05',        'units': '1',        'rendering_provider': {          'entity': '',          'organization_name': '',          'last_name': 'Franklin',          'first_name': 'John',          'npi': '1234567893'        }      }    ]  }}";
        }
        [TestMethod]
        [TestCategory("Claim")]
        public void ClaimCreationWithHasParamTest()
        {
            Hashtable input = JsonConvert.DeserializeObject<Hashtable>(ClaimInput);

            ClaimResponse actualResponse = claim.Create(input);

            ClaimSuccessCheck(actualResponse.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Claim")]
        public void ClaimCreationWithRequestOptionsTest()
        {
            RequestOptions options = new RequestOptions();
            options.IsTest = true;
            options.ApiKey = null;
            Hashtable input = JsonConvert.DeserializeObject<Hashtable>(ClaimInput);

            ClaimResponse actualResponse = claim.Create(input, options);

            ClaimSuccessCheck(actualResponse.JsonResponse());
        }

        //[TestMethod]
        //[TestCategory("Claim")]
        //[ExpectedException(typeof(EligibleService.Exceptions.EligibleException))]
        //public void ClaimCreationWithHasParamEligibleExceptionTest()
        //{
        //    Hashtable input = new Hashtable();

        //    ClaimResponse actualResponse = claim.Create(input);
        //}

        [TestMethod]
        [TestCategory("Claim")]
        public void ClaimCreationWithClaimParamsObjectTest()
        {
            ClaimParams input = JsonConvert.DeserializeObject<ClaimParams>(ClaimInput);
            RequestOptions options = new RequestOptions();
            options.IsTest = true;

            ClaimResponse actualResponse = claim.Create(input, options);
            ClaimSuccessCheck(actualResponse.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Claim")]
        public void ClaimCreationWithJsonStringTest()
        {

            ClaimResponse actualResponse = claim.Create(ClaimInput);
            ClaimSuccessCheck(actualResponse.JsonResponse());
        }

        [TestMethod]
        [TestCategory("Claim")]
        [ExpectedException(typeof(EligibleService.Exceptions.AuthenticationException))]
        public void ClaimCreateAuthenticationExpceptionTest()
        {
            Eligible config = Eligible.Instance;
            config.ApiKey = "Invalid key";
            config.IsTest = true;

            ClaimResponse actualResponse = claim.Create(ClaimInput);
        }

        private static void ClaimSuccessCheck(string actualResponse)
        {
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "ClaimSuccess.json");

            TestHelper.CompareProperties(expectedResponse, actualResponse);

            ClaimResponse expectedObj = JsonConvert.DeserializeObject<ClaimResponse>(expectedResponse);
            ClaimResponse actualObj = JsonConvert.DeserializeObject<ClaimResponse>(actualResponse);
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("Claim")]
        public void ClaimAcknowledgementsTest()
        {

            ClaimAcknowledgementsResponse actualResponse = claim.GetClaimAcknowledgements("12121212");

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "ClaimAcknowledgements.json");

            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            ClaimAcknowledgementsResponse expectedObj = JsonConvert.DeserializeObject<ClaimAcknowledgementsResponse>(expectedResponse);
            ClaimAcknowledgementsResponse actualObj = JsonConvert.DeserializeObject<ClaimAcknowledgementsResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("Claim")]
        public void ClaimMultipleAcknowledgementsTest()
        {
            Hashtable input = new Hashtable();
            input.Add("internal_id", "12345");
            input.Add("submission_status", "accepted");
            input.Add("claim_submitted_date", "2014-02-15");

            MultipleAcknowledgementsResponse actualResponse = claim.GetClaimAcknowledgements(input);

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "ClaimMultipleAcknowledgements.json");

            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            MultipleAcknowledgementsResponse expectedObj = JsonConvert.DeserializeObject<MultipleAcknowledgementsResponse>(expectedResponse);
            MultipleAcknowledgementsResponse actualObj = JsonConvert.DeserializeObject<MultipleAcknowledgementsResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("Claim")]
        public void ClaimPayementReportTest()
        {

            ClaimPaymentReportResponse actualResponse = claim.GetClaimPaymentReport("8IZ9JZI2FUEDCS");

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "ClaimPayementReports.json");

            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            ClaimPaymentReportResponse expectedObj = JsonConvert.DeserializeObject<ClaimPaymentReportResponse>(expectedResponse);
            ClaimPaymentReportResponse actualObj = JsonConvert.DeserializeObject<ClaimPaymentReportResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("Claim")]
        public void ClaimSpecificPayementReportTest()
        {

            ClaimPaymentReportResponse actualResponse = claim.GetClaimPaymentReport("8IZ9JZI2FUEDCS", "UP4OCS4PUY455");

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "ClaimPaymentReport.json");

            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            ClaimPaymentReportResponse expectedObj = JsonConvert.DeserializeObject<ClaimPaymentReportResponse>(expectedResponse);
            ClaimPaymentReportResponse actualObj = JsonConvert.DeserializeObject<ClaimPaymentReportResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("Claim")]
        public void ClaimPayementReportsTest()
        {

            ClaimPaymentReportsResponse actualResponse = claim.GetClaimPaymentReport();

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "PaymentReports.json");

            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            ClaimPaymentReportsResponse expectedObj = JsonConvert.DeserializeObject<ClaimPaymentReportsResponse>(expectedResponse);
            ClaimPaymentReportsResponse actualObj = JsonConvert.DeserializeObject<ClaimPaymentReportsResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }
    }
}
