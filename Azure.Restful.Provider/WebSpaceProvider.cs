using Azure.Restful.Model;
using Azure.Restful.Model.WebSite;
using Azure.Restful.Common;

namespace Azure.Restful.Provider
{
    public class WebSpaceProvider : BaseProvider<WebSpace>
    {
        public WebSpaceProvider(SubscriptionAccount subscriptionAccount)
            : base(subscriptionAccount)
        {
        }

        public WebSpaceProvider()
            : this(null)
        {

        }
    }
}
