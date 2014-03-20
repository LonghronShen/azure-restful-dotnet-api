using System;
using System.Collections.Generic;
using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.WebSite
{
    public class WebSite : BaseEntity
    {
        public bool AdminEnabled { get; set; }
        public bool AlwaysOn { get; set; }
        public string AvailabilityState { get; set; }
        public string ComputeMode { get; set; }
        public string ContentAvailabilityState { get; set; }
        public string DeploymentId { get; set; }
        public bool Enabled { get; set; }
        public List<string> EnabledHostNames { get; set; }
        public List<HostNameSslState> HostNameSslStates { get; set; }
        public List<string> HostNames { get; set; }
        public DateTime LastModifiedTimeUtc { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string RepositorySiteName { get; set; }
        public string RuntimeAvailabilityState { get; set; }
        public List<Certificate> SSLCertificates { get; set; }
        public string SelfLink { get; set; }
        public string ServerFarm { get; set; }
        public string SiteConfig { get; set; }
        public string SiteMode { get; set; }
        public string SiteProperties { get; set; }
        public SiteProperties SitePropertie { get; set; }
        public string State { get; set; }
        public string StorageRecoveryDefaultState { get; set; }
        public string UsageState { get; set; }
        public string WebSpace { get; set; }
    }
}
