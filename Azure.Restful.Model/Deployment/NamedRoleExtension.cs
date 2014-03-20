using System.Collections.Generic;

namespace Azure.Restful.Model.Deployment
{
    public class NamedRoleExtension
    {
        public string RoleName { get; set; }
        public List<Extension> Extensions { get; set; }
    }
}
