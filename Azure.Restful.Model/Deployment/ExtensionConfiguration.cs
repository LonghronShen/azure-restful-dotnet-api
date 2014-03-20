using System.Collections.Generic;

namespace Azure.Restful.Model.Deployment
{
    public class ExtensionConfiguration
    {
        public List<Extension> AllRoles { get; set; }
        public List<NamedRoleExtension> NamedRoles { get; set; }
    }
}
