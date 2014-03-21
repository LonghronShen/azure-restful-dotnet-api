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
                    _certificate = new X509Certificate2(GetBytes(CertificateRawData));
                    return _certificate;
                }

                if (!string.IsNullOrEmpty(CertificateThumbprint))
                {
                    StoreLocation[] locations = {StoreLocation.CurrentUser, StoreLocation.LocalMachine};
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
                                _certificate = certificates[0];
                                return _certificate;
                            }
                        }
                        finally
                        {
                            store.Close();
                        }
                    }
                }

                return null;
            }
        }

        private byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        } 
    }
}
