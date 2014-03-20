using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.Disk
{
    public class AttachedTo : BaseEntity
    {
        public string HostedServiceName { get; set; }
        public string DeploymentName { get; set; }
        public string RoleName { get; set; }
    }
}
