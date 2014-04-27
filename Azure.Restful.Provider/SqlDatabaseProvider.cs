using System.Collections.Generic;
using Azure.Restful.Model;
using Azure.Restful.Model.SqlAzure;
using Azure.Restful.Common;

namespace Azure.Restful.Provider
{
    public class SqlDatabaseProvider : BaseProvider<ServiceResource>
    {
        private string serverName;

        public SqlDatabaseProvider(SubscriptionAccount subscriptionAccount, string serverName)
            : base(subscriptionAccount)
        {
            this.provider = SqlAzureRestApiClient.Instance;
            this.serverName = serverName;
        }

        public SqlDatabaseProvider()
            : this(null, null)
        {

        }

        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }

        public override IEnumerable<ServiceResource> GetList()
        {
            string opName = "ListServiceResource";
            RequestInfo request = XmlProvider.CreateRequestInfo<ServiceResource>(opName, null);
            request.Url = GenerateUrl(request.Url, serverName);
            return provider.GetResponseEntities<ServiceResource>(subscriptionAccount, request);
        }
    }
}
