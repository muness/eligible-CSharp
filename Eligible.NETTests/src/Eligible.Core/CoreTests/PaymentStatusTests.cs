using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EligibleService.Core.CoreTests;
using System.Collections;
using EligibleService.Model;
using EligibleService.Core.Tests;
using EligibleService.NETTests;
using Newtonsoft.Json;

namespace EligibleService.Core.CoreTests
{
    [TestClass]
    public class PaymentStatusTests
    {
        PaymentStatus paymentStatus;
        [TestInitialize]
        public void Setup()
        {
            paymentStatus = new PaymentStatus();
            BaseTestClass.SetConfiguration();
        }

        [TestMethod]
        [TestCategory("PaymentStatus")]
        public void CostEstimatesTest()
        {
            PayementStatusResponse actualResponse = paymentStatus.Get(PaymentStatusParams());

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "paymentStatus.json");
            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            PayementStatusResponse expectedObj = JsonConvert.DeserializeObject<PayementStatusResponse>(expectedResponse);
            PayementStatusResponse actualObj = JsonConvert.DeserializeObject<PayementStatusResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("PaymentStatus")]
        [ExpectedException(typeof(EligibleService.Exceptions.EligibleException))]
        public void CostEstimatesEligibleExceptionTest()
        {
            Hashtable input = new Hashtable();
            var actualResponse = paymentStatus.Get(input);
        }

        private Hashtable PaymentStatusParams()
        {
            Hashtable param = new Hashtable();
            param.Add("provider_npi", "0123456789");
            param.Add("provider_tax_id", "111223333");
            param.Add("payer_id", "00001");
            param.Add("provider_last_name", "Doe");
            param.Add("provider_first_name", "John");
            param.Add("member_id", "ZZZ445554301");
            param.Add("member_first_name", "IDA");
            param.Add("member_last_name", "FRANKLIN");
            param.Add("member_dob", "1701-12-12");
            param.Add("service_type", "1");
            param.Add("payer_control_number", "123123123");
            param.Add("charge_amount", "125.00");
            param.Add("start_date", "2010-06-15");
            param.Add("end_date", "2010-06-15");
            param.Add("trace_number", "BHUYTOK98IK");

            return param;
        }
    }
}
