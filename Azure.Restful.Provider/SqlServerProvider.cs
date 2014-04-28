using Azure.Restful.Model;
using Azure.Restful.Common;
using Azure.Restful.Model.SqlAzure;

namespace Azure.Restful.Provider
{
    public class SqlServerProvider : BaseProvider<Server>
    {
        public SqlServerProvider(SubscriptionAccount subscriptionAccount)
            : base(subscriptionAccount)
        {
            provider = SqlAzureRestApiClient.Instance;
        }

        public SqlServerProvider()
            : this(null)
        {

        }
    }
}
