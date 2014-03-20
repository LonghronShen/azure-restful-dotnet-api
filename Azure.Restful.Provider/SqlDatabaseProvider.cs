using System.Collections.Generic;
using Azure.Restful.Model;
using Azure.Restful.Model.SqlAzure;
using Azure.Restful.Common;

namespace Azure.Restful.Provider
{
    public class SqlDatabaseProvider : BaseProvider<ServiceResource>
    {
        private string _serverName;

        public SqlDatabaseProvider(SubscriptionAccount subscriptionAccount, string serverName)
            : base(subscriptionAccount)
        {
            _provider = SqlAzureRestApiClient.Instance;
            _serverName = serverName;
        }

        public override IEnumerable<ServiceResource> GetList()
        {
            string opName = "ListServiceResource";
            RequestInfo request = XmlProvider.CreateRequestInfo<ServiceResource>(opName, null);
            request.Url = GenerateUrl(request.Url, _serverName);
            return _provider.GetResponseEntities<ServiceResource>(subscriptionAccount, request);
        }
    }
}
