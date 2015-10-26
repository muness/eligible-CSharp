using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EligibleService.Core;
using EligibleService.Model;
using EligibleService.Core.Tests;
using EligibleService.NETTests;
using Newtonsoft.Json;

namespace EligibleService.Core.CoreTests
{
    [TestClass]
    public class RealtimeClaimsTests
    {
        public string RealtimeClaimsInput { get; set; }
        RealtimeClaims realtimeClaims;
        [TestInitialize]
        public void Setup()
        {
            realtimeClaims = new RealtimeClaims();
            BaseTestClass.SetConfiguration();
            RealtimeClaimsInput = "{'estimation': 'true' ,'billing_provider': {    'tax_id': '27-4070722',    'tax_id_type': 'EI',    'entity': 'false',    'phone_number': '(206) 228-1234',    'organization_name': 'Eligible Inc',    'last_name': 'Some',    'first_name': 'Provider',    'middle_name': '',    'address': {      'street_line_1': '1842 Union Street',      'street_line_2': '',      'city': 'San Francisco',      'state': 'CA',      'zip': '94123'    },    'npi': '1234567890',    'taxonomy_code': '101YM0800X'  },  'payer': {    'id': '35145',    'name': 'Highmark',    'address': {      'street_line_1': '614 MARKET STREET',      'street_line_2': '',      'city': 'PARKERSBURG',      'state': 'WV',      'zip': '94123'    }  },  'subscriber': {    'id': '1234567890',    'first_name': 'Benjamin',    'last_name': 'Franklin',    'middle_name': '',    'address': {      'street_line_1': '123 NW St',      'street_line_2': '',      'city': 'Seattle',      'state': 'WA',      'zip': '98117'    },    'phone_number': '9129129121',    'group_id': '100012345',    'dob': '1974-02-06',    'gender': 'M',    'group_name': ''  },  'dependent': {    'last_name': 'Franklin',    'first_name': 'Cheryl',    'middle_name': '',    'dob': '1976-03-06',    'gender': 'F',    'address': {      'street_line_1': '123 NW St',      'street_line_2': '',      'city': 'Seattle',      'state': 'WA',      'zip': '98117'    },    'relationship': '1',    'phone_number': '9129129123'  },  'claim': {    'patient_signature_on_file': 'Y',    'direct_payment_authorized': 'Y',    'frequency': '1',    'prior_authorization_number': '1234567890',    'accept_assignment_code': 'C',    'total_charge': '118.05',    'patient_amount_paid': '0',    'provider_signature_on_file': 'Y',    'diagnosis_codes': [      '309.24',      '390.0'    ],    'service_lines': [      {        'service_date_from': '2014-05-07',        'service_date_to': '2014-05-07',        'place_of_service': '11',        'procedure_code': '90837',        'procedure_modifiers': [            'UN'        ],        'diagnosis_code_pointers': [          '1'        ],        'charge_amount': '118.05',        'units': '1',        'rendering_provider': {          'entity': '',          'organization_name': '',          'last_name': 'Franklin',          'first_name': 'John',          'npi': '1437311111'        }      }    ]  }}";
        }

        [TestMethod]
        [TestCategory("Realtime Claim Creation")]
        public void RealtimeClaimsSubmissionWithJsonParams()
        {
            RealtimeClaimsResponse actualResponse = realtimeClaims.Create(RealtimeClaimsInput);
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "ReatimeClaimResponse.json");

            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            RealtimeClaimsResponse expectedObj = JsonConvert.DeserializeObject<RealtimeClaimsResponse>(expectedResponse);
            RealtimeClaimsResponse actualObj = JsonConvert.DeserializeObject<RealtimeClaimsResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }
    }
}
