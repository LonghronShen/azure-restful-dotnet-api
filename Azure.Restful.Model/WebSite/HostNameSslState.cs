using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.WebSite
{
    public class HostNameSslState : BaseEntity
    {
        //check the description on : http://msdn.microsoft.com/en-us/library/azure/dn236426.aspx
        public string IPBasedSslState { get; set; }//Contains the status information for an SSL certificate bound to the web site.
        public string IpBasedSslResult { get; set; }//Unused
        public string Name { get; set; }//The Url of the web site.
        public string SslState { get; set; }//Disabled, SniEnabled or IpBasedEnabeled
        public string Thumbprint { get; set; }
        public bool ToUpdate { get; set; }//Unused
        public bool ToUpdateIpBasedSsl { get; set; }//Unused
        public string VirtualIP { get; set; }
    }
}
