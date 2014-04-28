using System.Collections.Generic;

namespace Azure.Restful.Model.Deployment
{
    public class ResourceExtensionReference
    {
        public string ReferenceName { get; set; }
        public string Publisher { get; set; }
        public string Name { get; set; }
        public List<ResourceExtensionParameterValue> ResourceExtensionParameterValues { get; set; }
        public string Version { get; set; }
        public string RoleName { get; set; }
        public string State { get; set; }
    }
}
