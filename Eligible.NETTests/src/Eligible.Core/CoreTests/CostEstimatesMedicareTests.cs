using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using EligibleService.Model;
using EligibleService.Core.Tests;
using EligibleService.NETTests;
using Newtonsoft.Json;

namespace EligibleService.Core.CoreTests
{
    [TestClass]
    public class CostEstimatesMedicareTests
    {
        CostEstimates costEstimates;
        [TestInitialize]
        public void Setup()
        {
            BaseTestClass.SetConfiguration();
            costEstimates = new CostEstimates();
        }

        [TestMethod]
        [TestCategory("CostEstimateMedicare")]
        public void CostEstimateMedicareTest()
        {
            Hashtable costEstimatesParams = CostEstimatesParams();
            costEstimatesParams["service_type"] = "67";

            try
            {
                CostEstimateMedicareResponse actualResponse = costEstimates.Medicare(costEstimatesParams);
                string expectedResponse = TestHelper.GetJson(TestResource.MocksPath + "CostEstimateMedicare.json");
                TestHelper.CompareProperties(expectedResponse, actualResponse.JsonResponse());
                CostEstimateMedicareResponse expectedObj = JsonConvert.DeserializeObject<CostEstimateMedicareResponse>(expectedResponse);
                CostEstimateMedicareResponse actualObj = JsonConvert.DeserializeObject<CostEstimateMedicareResponse>(actualResponse.JsonResponse());
                TestHelper.PropertyValuesAreEquals(actualObj, expectedObj);
            }
            catch(EligibleService.Exceptions.EligibleException ex)
            {
                Assert.AreEqual("Duplicate eligibility requests using the same NPI/HICN combination are not allowed in the same 24 hour period. Please try again after 24 hours.", ex.EligibleError.Errors[0].Message);
            }
        }
        
        private Hashtable CostEstimatesParams()
        {
            Hashtable param = new Hashtable();
            param.Add("provider_price", "1500.50");
            param.Add("network", "IN");
            param.Add("payer_id", "00431");
            param.Add("provider_last_name", "Doe");
            param.Add("provider_first_name", "John");
            param.Add("provider_npi", "0123456789");
            param.Add("member_id", "cost_medicare_001");
            param.Add("member_first_name", "IDA");
            param.Add("member_last_name", "FRANKLIN");
            param.Add("member_dob", "1701-12-12");

            return param;
        }
    }
}
