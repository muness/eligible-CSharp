using EligibleService.Net;
using NLog;

namespace EligibleService.Core
{
    /// <summary>
    /// Singleton class that sets apikey and test.
    /// This is mandatory for User. Otherwise will be getting issues while accessing other API bindings
    /// </summary>

    public class Eligible : RequestOptions
    {
        private string fingerprint;

        public string Fingerprint
        {
            get { return fingerprint; }
            set 
            { 
                fingerprint = value;
                Logger logger = LogManager.GetLogger("Fingerprint");
                logger.Error("Modifying the certificate fingerprint is not advised. This should only be done if instructed by eligible.com support. Please update to the latest version of the eligible library for certificate fingerprint updates.");
            }
        }
        private static Eligible instance;
        private static readonly object syncLock = new object();

        private Eligible() 
        {
            fingerprint = EligibleResources.Fingerprint;
            new EligibleService.Common.Logging();
        }
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
