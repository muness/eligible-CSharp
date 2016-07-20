using EligibleService.Net;
using NLog;
using System.Collections;

namespace EligibleService.Core
{
    /// <summary>
    /// Singleton class that sets apikey and test.
    /// This is mandatory for User. Otherwise will be getting issues while accessing other API bindings
    /// </summary>
    public class Eligible : RequestOptions
    {
        private Eligible()
        {
            this.fingerprints = new ArrayList();
            this.fingerprints.Add(EligibleResources.Fingerprint.Trim());
            this.fingerprints.Add(EligibleResources.SecondaryFingerprint.Trim());
            this.WhiteListedDomains = new ArrayList();
            this.WhiteListedDomains.Add(EligibleResources.WhiteListedDomain.Trim());

            new EligibleService.Common.Logging();
        }

        private static readonly object SyncLock = new object();

        private static Eligible instance;

        public static Eligible Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncLock)
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

        private ArrayList fingerprints;

        public ArrayList Fingerprints()
        {
            return this.fingerprints;
        }

        public void AddFingerprint(string fingerprint)
        {
            this.fingerprints.Add(fingerprint);

            Logger logger = LogManager.GetLogger("Fingerprint");
            logger.Error("Modifying the certificate fingerprint is not advised. This should only be done if instructed by eligible.com support. Please update to the latest version of the eligible library for certificate fingerprint updates.");
        }

        public ArrayList WhiteListedDomains { get; set; }
    }

    public class RequestOptions
    {
        public string ApiKey { get; set; }

        public bool? IsTest { get; set; }

        /// <summary>
        /// Optional property for mocking
        /// </summary>
        public string BaseUrl { get; set; }
    }
}
