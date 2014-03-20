using System.Collections.Generic;
using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.AffinityGroup
{
    public class AffinityGroup : BaseEntity
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<string> Capabilities { get; set; }
        public List<HostedService> HostedServices { get; set; }
    }
}
