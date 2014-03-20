using Azure.Restful.Model;
using Azure.Restful.Model.OSImage;
using Azure.Restful.Common;

namespace Azure.Restful.Provider
{
    public class OSImageProvider : BaseProvider<OSImage>
    {
        public OSImageProvider(SubscriptionAccount subscriptionAccount)
            : base(subscriptionAccount)
        {
            _provider = ServiceManagementRestApiClient.Instance;
        }
    }
}
