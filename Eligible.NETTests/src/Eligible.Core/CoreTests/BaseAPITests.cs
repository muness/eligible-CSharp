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
    public class BaseAPITests
    {
        public string ClaimInput { get; set; }
        Claim claim;

        [TestInitialize]
        public void Setup()
        {
            claim = new Claim();
            BaseTestClass.SetConfiguration();
            ClaimInput = "{'scrub_eligibility': 'false', 'billing_provider': {    'tax_id': '123456789',    'tax_id_type': 'EI',    'entity': 'false',    'phone_number': '1234567890',    'organization_name': 'ELIGIBLE INC',    'last_name': 'SOME',    'first_name': 'PROVIDER',    'middle_name': '',    'address': {      'street_line_1': '1842 UNION STREET',      'street_line_2': '',      'city': 'Seattle',      'state': 'WA',      'zip': '981011231'    },    'npi': '1234567893',    'taxonomy_code': '101YM0800X'  },  'payer': {    'id': '60054',    'name': 'Aetna',    'address': {      'street_line_1': '603 3rd Ave Van',      'street_line_2': '',      'city': 'San Francisco',      'state': 'CA',      'zip': '941231232'    }  },  'subscriber': {    'id': '89898989',    'first_name': 'Benjamin',    'last_name': 'Franklin',    'middle_name': '',    'address': {      'street_line_1': '123 NW St',      'street_line_2': '',      'city': 'Seattle',      'state': 'WA',      'zip': '981171232'    },    'phone_number': '9129129121',    'group_id': '100012345',    'dob': '1974-02-06',    'gender': 'M',    'group_name': ''  },  'dependent': {    'last_name': 'Franklin',    'first_name': 'Cheryl',    'middle_name': '',    'dob': '1976-03-06',    'gender': 'F',    'address': {      'street_line_1': '123 NW St',      'street_line_2': '',      'city': 'Seattle',      'state': 'WA',      'zip': '981171232'    },    'relationship': '01',    'phone_number': '9129129123'  },  'claim': {    'patient_signature_on_file': 'Y',    'direct_payment_authorized': 'Y',    'frequency': '1',    'prior_authorization_number': '1234567890',    'accept_assignment_code': 'C',    'total_charge': '118.05',    'patient_amount_paid': '0',    'provider_signature_on_file': 'Y',    'diagnosis_codes': [      '309.24', '309.0'   ],    'service_lines': [      {        'service_date_from': '2014-05-07',        'service_date_to': '2014-05-07',        'place_of_service': '11',        'procedure_code': '90837',        'procedure_modifiers': [            'UN'        ],        'diagnosis_code_pointers': [          '1'        ],        'charge_amount': '118.05',        'units': '1',        'rendering_provider': {          'entity': '',          'organization_name': '',          'last_name': 'Franklin',          'first_name': 'John',          'npi': '1234567893'        }      }    ]  }}";
        }

        [TestMethod]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void InvalidBaseUrlOptionTest()
        {
            Eligible config = Eligible.Instance;
            RequestOptions options = new RequestOptions();
            options.IsTest = true;
            options.ApiKey = config.ApiKey;
            options.BaseUrl = "https://www.example.com/";
            Hashtable input = JsonConvert.DeserializeObject<Hashtable>(ClaimInput);

            ClaimResponse actualResponse = claim.Create(input, options);
        }

        [TestMethod]
        public void ValidBaseUrlOptionTest()
        {
            Eligible config = Eligible.Instance;
            RequestOptions options = new RequestOptions();
            options.IsTest = true;
            options.ApiKey = config.ApiKey;
            options.BaseUrl = "https://gds.eligibleapi.com/";
            Hashtable input = JsonConvert.DeserializeObject<Hashtable>(ClaimInput);

            ClaimResponse actualResponse = claim.Create(input, options);
            Assert.IsNotNull(actualResponse.JsonResponse());
        }

        [TestMethod]
        public void InvalidAPIKeyOptionTest()
        {
            RequestOptions options = new RequestOptions();
            options.IsTest = true;
            options.ApiKey = "In-Valid";
            options.BaseUrl = "https://gds.eligibleapi.com/";
            Hashtable input = JsonConvert.DeserializeObject<Hashtable>(ClaimInput);

            try
            {
                ClaimResponse actualResponse = claim.Create(input, options);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Could not authenticate you. Please re-try with a valid API key.", ex.Message);
            }
        }
    }
}
