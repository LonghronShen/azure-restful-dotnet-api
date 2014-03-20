using System;
using System.Security.Cryptography.X509Certificates;
using Azure.Restful.Model.Base;
using System.Configuration;

namespace Azure.Restful.Model
{
    [Serializable]
    public class SubscriptionAccount : BaseEntity
    {
        private static readonly string ManagementCertificate = ConfigurationManager.AppSettings["ManagementCertificate"];
        public SubscriptionAccount(Guid subscriptionId, string serviceEndpoint)
            : this()
        {
            SubscriptionId = subscriptionId;
            ServiceEndpoint = serviceEndpoint;
        }

        public SubscriptionAccount()
        {
            CertificateThumbprint = ManagementCertificate;
        }

        public Guid SubscriptionId { get; set; }

        public string SubscriptionName { get; set; }

        private string _certificateThumbprint;
        public string CertificateThumbprint
        {
            get { return _certificateThumbprint; }
            set
            {
                if (string.Compare(_certificateThumbprint, value, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    _certificateThumbprint = value;
                    _certificate = null;
                }
            }
        }

        private X509Certificate2 _certificate;
        public X509Certificate2 Certificate
        {
            get
            {
                if (string.IsNullOrEmpty(CertificateThumbprint))
                {
                    _certificate = null;
                    return null;
                }
                if (_certificate != null)
                {
                    return _certificate;
                }
                StoreLocation[] locations = { StoreLocation.CurrentUser, StoreLocation.LocalMachine };
                foreach (StoreLocation location in locations)
                {
                    X509Store store = new X509Store("My", location);
                    try
                    {
                        store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                        X509Certificate2Collection certificates = store.Certificates.Find(X509FindType.FindByThumbprint, CertificateThumbprint, false);
                        if (certificates.Count > 0)
                        {
                            _certificate = certificates[0];
                            return _certificate;
                        }
                    }
                    finally
                    {
                        store.Close();
                    }
                }
                throw new ArgumentException(string.Format("A Certificate with Thumbprint '{0}' could not be located.", CertificateThumbprint));
            }
        }

        public string ServiceEndpoint { get; set; }

        public string SqlAzureServiceEndpoint { get; set; }

        public string CurrentStorageAccount { get; set; }
    }
}
