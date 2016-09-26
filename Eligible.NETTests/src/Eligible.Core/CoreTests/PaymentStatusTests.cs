using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EligibleService.Core.CoreTests;
using System.Collections;
using EligibleService.Model;
using EligibleService.Core.Tests;
using EligibleService.NETTests;
using Newtonsoft.Json;
using EligibleService.Exceptions;
using Newtonsoft.Json.Linq;

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
        public void PaymentStatusFinalisedButNoPaymentTest()
        {
            var hashParams = PaymentStatusParams();
            hashParams.Add("member_id", "10101010");

            PayementStatusResponse actualResponse = paymentStatus.Get(hashParams);

            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "paymentStatus.json");
            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            PayementStatusResponse expectedObj = JsonConvert.DeserializeObject<PayementStatusResponse>(expectedResponse);
            PayementStatusResponse actualObj = JsonConvert.DeserializeObject<PayementStatusResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("PaymentStatus")]
        public void PaymentStatusNotFoundTest()
        {
            var hashParams = PaymentStatusParams();
            hashParams.Add("member_id", "11111111");

            try
            {
                PayementStatusResponse actualResponse = paymentStatus.Get(hashParams);
            }
            catch (EligibleException ex)
            {
                Assert.IsNotNull(ex.EligibleError.EligibleId);
                Assert.IsNotNull(ex.EligibleError.CreatedAt);
                Assert.AreEqual("Y", ex.EligibleError.Error.ResponseCode);
                Assert.AreEqual("Yes", ex.EligibleError.Error.ResponseDescription);
                Assert.AreEqual("", ex.EligibleError.Error.AgencyQualifierCode);
                Assert.AreEqual("", ex.EligibleError.Error.AgencyQualifierDescription);
                Assert.AreEqual("A4", ex.EligibleError.Error.RejectReasonCode);
                Assert.AreEqual("Acknowledgement/Not Found-The claim/encounter can not be found in the adjudication system.", ex.EligibleError.Error.RejectReasonDescription);
                Assert.AreEqual("Cannot provide further status electronically.", ex.EligibleError.Error.Details);
                Assert.AreEqual("C", ex.EligibleError.Error.FollowUpActionCode);
                Assert.AreEqual("Please Correct and Resubmit", ex.EligibleError.Error.FollowUpActionDescription);
                Assert.AreEqual(0, ex.EligibleError.KnownIssues.Count);
            }
        }

        [TestMethod]
        [TestCategory("PaymentStatus")]
        public void PaymentStatusMoreInfoRequiredTest()
        {
            var hashParams = PaymentStatusParams();
            hashParams.Add("member_id", "12121212");

            try
            {
                PayementStatusResponse actualResponse = paymentStatus.Get(hashParams);
            }
            catch (Exception ex)
            {
                CoverageErrorDetails actualResponse = JsonConvert.DeserializeObject<CoverageErrorDetails>(ex.Message);
                string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "PaymentStatusNotFound.json");
                TestHelper.CompareProperties(expectedResponse, JsonConvert.SerializeObject(actualResponse));
            }
        }

        [TestMethod]
        [TestCategory("PaymentStatus")]
        public void PaymentStatusPaidTest()
        {
            var hashParams = PaymentStatusParams();
            hashParams.Add("member_id", "12312312");

            PayementStatusResponse actualResponse = paymentStatus.Get(hashParams);
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "PaymentStatusPaid.json");
            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            PayementStatusResponse expectedObj = JsonConvert.DeserializeObject<PayementStatusResponse>(expectedResponse);
            PayementStatusResponse actualObj = JsonConvert.DeserializeObject<PayementStatusResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        [TestMethod]
        [TestCategory("PaymentStatus")]
        public void PaymentStatusPendingTest()
        {
            var hashParams = PaymentStatusParams();
            hashParams.Add("member_id", "34343434");

            PayementStatusResponse actualResponse = paymentStatus.Get(hashParams);
            string expectedResponse = TestHelper.GetJson(TestResource.ExpectedResponse + "PaymentStatusPending.json");
            TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());

            PayementStatusResponse expectedObj = JsonConvert.DeserializeObject<PayementStatusResponse>(expectedResponse);
            PayementStatusResponse actualObj = JsonConvert.DeserializeObject<PayementStatusResponse>(actualResponse.JsonResponse());
            TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
        }

        private Hashtable PaymentStatusParams()
        {
            Hashtable param = new Hashtable();
            param.Add("provider_npi", "0123456789");
            param.Add("provider_tax_id", "111223333");
            param.Add("payer_id", "00001");
            param.Add("provider_last_name", "Doe");
            param.Add("provider_first_name", "John");
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
