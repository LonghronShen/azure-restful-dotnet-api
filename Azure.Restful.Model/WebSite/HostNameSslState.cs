using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.WebSite
{
    public class HostNameSslState : BaseEntity
    {
        public string IPBasedSslState { get; set; }
        public bool? IpBasedSslResult { get; set; }
        public string Name { get; set; }
        public string SslState { get; set; }
        public bool? Thumbprint { get; set; }
        public bool? ToUpdate { get; set; }
        public bool? ToUpdateIpBasedSsl { get; set; }
        public bool? VirtualIP { get; set; }
    }
}
