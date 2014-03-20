using System.Collections.Generic;

namespace Azure.Restful.Model.Deployment
{
    public class VirtualMachine
    {
        public string RoleName { get; set; }
        public string OsVersion { get; set; }
        public string RoleType { get; set; }
        public List<ConfigurationSet> ConfigurationSets { get; set; }
        public string AvailabilitySetName { get; set; }
        public List<DataVirtualHardDisk> DataVirtualHardDisks { get; set; }
        public OSVirtualHardDisk OSVirtualHardDisk { get; set; }
        public string RoleSize { get; set; }
        public bool ProvisionGuestAgent { get; set; }
        public string DefaultWinRmCertificateThumbprint { get; set; }
        public string DeploymentId { get; set; }
    }
}
