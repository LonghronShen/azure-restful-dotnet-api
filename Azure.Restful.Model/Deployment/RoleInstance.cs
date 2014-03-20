using System.Collections.Generic;

namespace Azure.Restful.Model.Deployment
{
    public class RoleInstance
    {
        public string RoleName { get; set; }
        public string InstanceName { get; set; }
        public string InstanceStatus { get; set; }
        public int InstanceUpgradeDomain { get; set; }
        public int InstanceFaultDomain { get; set; }
        public string InstanceSize { get; set; }
        public string InstanceStateDetails { get; set; }
        public string InstanceErrorCode { get; set; }
        public string IpAddress { get; set; }
        public List<InstanceEndpoint> InstanceEndpoints { get; set; }
        public string PowerState { get; set; }
        public string HostName { get; set; }
        public string RemoteAccessCertificateThumbprint { get; set; }
    }
}
