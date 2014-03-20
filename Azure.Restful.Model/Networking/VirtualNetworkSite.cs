using System;
using System.Collections.Generic;
using Azure.Restful.Model.Deployment;

namespace Azure.Restful.Model.Networking
{
    public class VirtualNetworkSite
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public Guid Id { get; set; }
        public string AffinityGroup { get; set; }
        public string State { get; set; }
        public bool InUse { get; set; }
        public AddressSpace AddressSpace { get; set; }
        public List<Subnet> Subnets { get; set; }
        public Dns Dns { get; set; }
        public Gateway Gateway { get; set; }
    }
}
