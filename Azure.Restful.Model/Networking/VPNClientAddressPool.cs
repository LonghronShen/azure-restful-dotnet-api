using System.Collections.Generic;

namespace Azure.Restful.Model.Networking
{
    public class VPNClientAddressPool
    {
        public string Name { get; set; }
        public List<string> AddressPrefixes { get; set; }
    }
}
