using System;
using System.Collections.Generic;
using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.Deployment
{
    public class Deployment
    {
        public string Name { get; set; }
        public string DeploymentSlot { get; set; }
        public string PrivateID { get; set; }
        public string Status { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        public string Configuration { get; set; }
        public List<RoleInstance> RoleInstanceList { get; set; }
        public UpgradeStatus UpgradeStatus { get; set; }
        public int UpgradeDomainCount { get; set; }
        public List<Role> RoleList { get; set; }
        public string SdkVersion { get; set; }
        public bool Locked { get; set; }
        public bool RollbackAllowed { get; set; }
        public string VirtualNetworkName { get; set; }
        public Dns Dns { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public List<ExtendedProperty> ExtendedProperties { get; set; }
        public PersistentVMDowntime PersistentVMDowntime { get; set; }
        public List<VirtualIP> VirtualIPs { get; set; }
        public ExtensionConfiguration ExtensionConfiguration { get; set; }
        public string InternalDnsSuffix { get; set; }
    }
}