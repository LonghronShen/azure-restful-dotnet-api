using Azure.Restful.Model;
using Azure.Restful.Model.AffinityGroup;
using Azure.Restful.Common;

namespace Azure.Restful.Provider
{
    public class AffinityGroupProvider : BaseProvider<AffinityGroup>
    {

        public AffinityGroupProvider(SubscriptionAccount subscriptionAccount)
            : base(subscriptionAccount)
        {
        }

        public AffinityGroupProvider()
            : this(null)
        {
        }
    }
}
