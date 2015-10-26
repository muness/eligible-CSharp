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
            config.ApiKey = "Api Key";
            config.ApiVersion = "v1.5";
            config.TestMode = true;

        }
    }
}
