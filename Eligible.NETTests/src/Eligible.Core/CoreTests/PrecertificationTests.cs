using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using EligibleService.Model;
using EligibleService.NETTests;
using EligibleService.Core.Tests;
using Newtonsoft.Json;

namespace EligibleService.Core.CoreTests
{
    [TestClass]
    public class PrecertificationTests
    {
        public string PrecertificationInput { get; set; }
        Precertification precertification;
        [TestInitialize]
        public void Setup()
        {
            precertification = new Precertification();
            BaseTestClass.SetConfiguration();
        }

        [TestMethod]
        [TestCategory("Precertification")]
        public void PrecertificationInquiryTest()
        {
            PrecertificationInquiryResponse response = precertification.Inquiry(PrecertificationParams());
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "PrecertificationInquiry.json");
            TestHelper.CompareProperties(expectedResponse, response.JsonResponse());

            PrecertificationInquiryResponse expectedObj = JsonConvert.DeserializeObject<PrecertificationInquiryResponse>(expectedResponse);
            PrecertificationInquiryResponse actualObj = JsonConvert.DeserializeObject<PrecertificationInquiryResponse>(response.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        private Hashtable PrecertificationParams()
        {
            Hashtable param = new Hashtable();
            param.Add("payer_id", "00001");
            param.Add("payer_name", "Aetna");
            param.Add("provider_type", "attending");
            param.Add("provider_last_name", "Doe");
            param.Add("provider_first_name", "John");
            param.Add("provider_npi", "0123456789");
            param.Add("provider_phone_number", "1234567890");
            param.Add("provider_taxonomy_code", "291U00000X");
            param.Add("member_id", "AETNAS8398");
            param.Add("member_first_name", "IDA");
            param.Add("member_last_name", "FRANKLIN");
            param.Add("member_dob", "1701-12-12");

            return param;
        }
    }
}
