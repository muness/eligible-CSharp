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
            this.Fingerprints = new ArrayList();
            this.Fingerprints.Add(EligibleResources.Fingerprint.Trim());
            this.Fingerprints.Add(EligibleResources.SecondaryFingerprint.Trim());

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

        public ArrayList Fingerprints { get; set; }

        public void SetFingerprint(string fingerprint)
        {
            this.Fingerprints.Add(fingerprint);
            Logger logger = LogManager.GetLogger("Fingerprint");
            logger.Error("Modifying the certificate fingerprint is not advised. This should only be done if instructed by eligible.com support. Please update to the latest version of the eligible library for certificate fingerprint updates.");
        }
    }

    public class RequestOptions
    {
        public string ApiKey { get; set; }

        public bool? IsTest { get; set; }
    }
}
