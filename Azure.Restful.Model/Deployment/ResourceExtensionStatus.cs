using System.Collections.Generic;
namespace Azure.Restful.Model.Deployment
{
    public class ResourceExtensionStatus
    {
        public string HandlerName { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
        public FormattedMessage FormattedMessage { get; set; }
    }
}
