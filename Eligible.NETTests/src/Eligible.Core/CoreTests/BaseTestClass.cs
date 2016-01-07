using EligibleService.NETTests;
using System;

namespace EligibleService.Core.CoreTests
{
    public class BaseTestClass
    {
        public static void SetConfiguration()
        {
            Eligible config = Eligible.Instance;
            string value = TestResource.apikey;
            config.ApiKey = (String.IsNullOrEmpty(value)) ? Environment.GetEnvironmentVariable("apikey") : value;
            config.IsTest = true;
        }
    }
}
