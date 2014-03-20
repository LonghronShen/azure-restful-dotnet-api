using Azure.Restful.Model;
using Azure.Restful.Model.Subscription;
using Azure.Restful.Common;

namespace Azure.Restful.Provider
{
    public class SubscriptionProvider : BaseProvider<Subscription>
    {

        public SubscriptionProvider(SubscriptionAccount subscriptionAccount)
            : base(subscriptionAccount)
        {
            _provider = ServiceManagementRestApiClient.Instance;
        }

        public Subscription GetSingle()
        {
            return GetSingle("");
        }
    }
}
