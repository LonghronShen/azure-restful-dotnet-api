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
        }

        public SubscriptionProvider()
            : this(null)
        {

        }

        public Subscription GetSingle()
        {
            return GetSingle("");
        }
    }
}
