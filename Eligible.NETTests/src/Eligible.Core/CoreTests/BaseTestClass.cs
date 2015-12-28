using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Core.CoreTests
{
    public class BaseTestClass
    {
        public static void SetConfiguration()
        {
            Eligible config = Eligible.Instance;
            string value = System.Configuration.ConfigurationManager.AppSettings["apikey"];
            config.ApiKey = (String.IsNullOrEmpty(value)) ? Environment.GetEnvironmentVariable("apikey") : value;
            config.IsTest = true;
        }
    }
}
