using System;
using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.Subscription
{
    public class Subscription : BaseEntity
    {
        public Guid SubscriptionID { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionStatus { get; set; }
        public string AccountAdminLiveEmailId { get; set; }
        public string ServiceAdminLiveEmailId { get; set; }
        public int MaxCoreCount { get; set; }
        public int MaxStorageAccounts { get; set; }
        public int MaxHostedServices { get; set; }
        public int CurrentCoreCount { get; set; }
        public int CurrentHostedServices { get; set; }
        public int CurrentStorageAccounts { get; set; }
        public int MaxVirtualNetworkSites { get; set; }
        public int CurrentVirtualNetworkSites { get; set; }
        public int MaxLocalNetworkSites { get; set; }
        public int CurrentLocalNetworkSites { get; set; }
        public int MaxDnsServers { get; set; }
        public int CurrentDnsServers { get; set; }
        public string OfferCategories { get; set; }
        public int MaxExtraVIPCount { get; set; }
        public Guid AADTenantID { get; set; }
        public int MaxReservedIPs { get; set; }
        public int CurrentReservedIPs { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
