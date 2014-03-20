using Azure.Restful.Model;
using Azure.Restful.Model.Disk;
using Azure.Restful.Common;

namespace Azure.Restful.Provider
{
    public class DiskProvider : BaseProvider<Disk>
    {

        public DiskProvider(SubscriptionAccount subscriptionAccount)
            : base(subscriptionAccount)
        {
            _provider = ServiceManagementRestApiClient.Instance;
        }

    }
}
