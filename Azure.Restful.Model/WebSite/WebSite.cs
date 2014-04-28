using System;
using System.Collections.Generic;
using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.WebSite
{
    public class WebSite : BaseEntity
    {
        //check description on this site: http://msdn.microsoft.com/en-us/library/azure/dn236426.aspx
        public bool AdminEnabled { get; set; }//always true.        

        //todo:remove the 'AlwaysOn' property.
        public bool AlwaysOn { get; set; }
        public string AvailabilityState { get; set; }//'Normal' or 'Limited'

        //todo: what's the means of Cers and the Type is???
        public string Cers { get; set; }
        public string ComputeMode { get; set; }//Shared or Dedicated
        public string ContentAvailabilityState { get; set; }//Unused

        //todo: waht's the means of Csrs and the Type is???
        public string Csrs { get; set; }
        public string DeploymentId { get; set; }
        public bool Enabled { get; set; }
        public List<string> EnabledHostNames { get; set; }
        public List<HostNameSslState> HostNameSslStates { get; set; }
        public List<string> HostNames { get; set; }
        public bool IntegratedSqlAuthEnabled { get; set; }
        public DateTime LastModifiedTimeUtc { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string RepositorySiteName { get; set; }
        public string RuntimeADUser { get; set; }
        public string RuntimeADUserDomain { get; set; }
        public string RuntimeADUserPassword { get; set; }
        public string RuntimeAvailabilityState { get; set; }//Normal, Degraded, or NotAvailable
        public string SKU { get; set; }
        public List<Certificate> SSLCertificates { get; set; }
        public string SelfLink { get; set; }
        public string ServerFarm { get; set; }
        public string SiteConfig { get; set; }
        //SiteMode: String that represents the web site mode. If the web site mode is Free, this value is Limited. If the web site mode is Shared, this value is Basic.
        //The SiteMode value is not used for Standard mode. Standard mode uses the ComputeMode setting.
        public string SiteMode { get; set; }
        public SiteProperties SiteProperties { get; set; }
        public string State { get; set; }//Stopped or Running
        public string StorageRecoveryDefaultState { get; set; }//Unused
        public List<string> TrafficManagerHostNames { get; set; }
        public string UsageState { get; set; }//Possible values are Normal or Exceeded. If any quota is exceeded, the UsageState value changes to Exceeded and the site goes off line
        public string WebHostingPlan { get; set; }
        public string WebSpace { get; set; }
        public bool WindowsAuthEnabled { get; set; }
    }
}
