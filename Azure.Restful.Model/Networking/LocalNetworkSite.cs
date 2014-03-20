using System.Collections.Generic;

namespace Azure.Restful.Model.Networking
{
    public class LocalNetworkSite
    {
        public string Name { get; set; }
        public AddressSpace AddressSpace { get; set; }
        public string VpnGatewayAddress { get; set; }
        public List<Connection> Connections { get; set; }
    }
}
