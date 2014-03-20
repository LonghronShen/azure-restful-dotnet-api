using System.Collections.Generic;
using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.Deployment
{
    public class UpgradeDeploymentDefination
    {
        public string Mode { get; set; }
        public string PackageUrl { get; set; }
        public string Configuration { get; set; }
        public string Label { get; set; }
        public string RoleToUpgrade { get; set; }
        public bool Force { get; set; }
        public List<ExtendedProperty> ExtendedProperties { get; set; }
        public ExtensionConfiguration ExtensionConfiguration { get; set; }
    }
}
