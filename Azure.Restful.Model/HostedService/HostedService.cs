using Azure.Restful.Model.Base;

namespace Azure.Restful.Model
{
    public class HostedService : BaseEntity
    {
        public HostedService()
        {
            HostedServiceProperties = new HostedServiceProperties();
        }

        public string Url { get; set; }
        public string ServiceName { get; set; }

        public HostedServiceProperties HostedServiceProperties { get; set; }
        public string DefaultWinRmCertificateThumbprint { get; set; }
    }
}
