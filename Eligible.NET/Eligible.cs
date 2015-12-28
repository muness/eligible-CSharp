using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Runtime.InteropServices;

namespace EligibleService.Core
{
    /// <summary>
    /// Singleton class that sets apikey and test.
    /// This is mandatory for User. Otherwise will be getting issues while accessing other API bindings
    /// </summary>

    public class Eligible : RequestOptions
    {
        private static Eligible instance;
        private static readonly object syncLock = new object();

        private Eligible() { }
        public static Eligible Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new Eligible();
                        }
                    }
                }

                return instance;
            }
        }
    }

    public class RequestOptions
    {
        public string ApiKey { get; set; }
        public bool? IsTest { get; set; }
    }
}
