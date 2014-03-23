using System;
using System.Security.Cryptography.X509Certificates;
using Azure.Restful.Model.Base;

namespace Azure.Restful.Model
{
    [Serializable]
    public class SubscriptionAccount : BaseEntity
    {
        public SubscriptionAccount(Guid subscriptionId, string serviceEndpoint)
            : this()
        {
            SubscriptionId = subscriptionId;
            ServiceEndpoint = serviceEndpoint;
        }

        public SubscriptionAccount() { }

        public Guid SubscriptionId { get; set; }

        public string SubscriptionName { get; set; }

        public string ServiceEndpoint { get; set; }

        public string SqlAzureServiceEndpoint { get; set; }

        public string CertificateRawData { get; set; }

        public string CertificateThumbprint { get; set; }

        private X509Certificate2 _certificate;
        public X509Certificate2 Certificate
        {
            get
            {
                if (_certificate != null)
                {
                    return _certificate;
                }

                if (string.IsNullOrEmpty(CertificateRawData) && string.IsNullOrEmpty(CertificateThumbprint))
                {
                    throw new Exception("Please specify either CertificateRawData or CertificateThumbprint");
                }

                if (!string.IsNullOrEmpty(CertificateRawData))
                {
                    return CreateCertificateFromRawData(CertificateRawData);
                }

                if (!string.IsNullOrEmpty(CertificateThumbprint))
                {
                    return CreateCertificateFromThumbprint(CertificateThumbprint);
                }
                return null;
            }
        }

        private X509Certificate2 CreateCertificateFromRawData(string certRawData)
        {
            if (string.IsNullOrEmpty(certRawData))
            {
                throw new ArgumentNullException("certRawData");
            }
            return new X509Certificate2(Convert.FromBase64String(CertificateRawData));
        }

        private X509Certificate2 CreateCertificateFromThumbprint(string certThumbprint)
        {
            if (string.IsNullOrEmpty(certThumbprint))
            {
                throw new ArgumentNullException("certThumbprint");
            }

            StoreLocation[] locations = { StoreLocation.CurrentUser, StoreLocation.LocalMachine };
            foreach (StoreLocation location in locations)
            {
                X509Store store = new X509Store("My", location);
                try
                {
                    store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                    X509Certificate2Collection certificates =
                        store.Certificates.Find(X509FindType.FindByThumbprint, CertificateThumbprint, false);
                    if (certificates.Count > 0)
                    {
                        return certificates[0];
                    }
                }
                finally
                {
                    store.Close();
                }
            }
            throw new Exception("Can not find certification by cert thumbprint " + certThumbprint);
        }
    }
}
