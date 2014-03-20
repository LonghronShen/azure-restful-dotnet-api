using System.Collections.Generic;

namespace Azure.Restful.Model.Networking
{
    public class Gateway
    {
        public string Profile { get; set; }
        public string AddressPrefix { get; set; }
        public List<LocalNetworkSite> Sites { get; set; }
        public VPNClientAddressPool VPNClientAddressPool { get; set; }
    }
}
