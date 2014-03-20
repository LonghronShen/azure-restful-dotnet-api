using System.Collections.Generic;

namespace Azure.Restful.Model.Deployment
{
    public class ConfigurationSet
    {
        public string ConfigurationSetType { get; set; }
        public string ComputerName { get; set; }
        public List<InputEndpoint> InputEndpoints { get; set; }
        public List<string> SubnetNames { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }

        public string EnableAutomaticUpdates { get; set; }
        public string TimeZone { get; set; }
        public StoredCertificateSettings StoredCertificateSettings { get; set; }

        
    }
}
