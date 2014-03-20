using System.Collections.Generic;
using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.Deployment
{
    public class DeploymentDefination
    {
        public string Name { get; set; }
        public string PackageUrl { get; set; }
        public string Label { get; set; }
        public string Configuration { get; set; }
        public string StartDeployment { get; set; }
        public string TreatWarningsAsError { get; set; }
        public List<ExtendedProperty> ExtendedProperties { get; set; }
        public ExtensionConfiguration ExtensionConfiguration { get; set; }
    }
}
