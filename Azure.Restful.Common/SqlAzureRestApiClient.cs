

using Azure.Restful.Model;
namespace Azure.Restful.Common
{
    public class SqlAzureRestApiClient : BaseRestApiClient
    {
        private static SqlAzureRestApiClient _provider;
        private static readonly object _locker = new object();

        private SqlAzureRestApiClient() { }

        public static SqlAzureRestApiClient Instance
        {
            get
            {
                if (_provider == null)
                {
                    lock (_locker)
                    {
                        if (_provider == null)
                        {
                            _provider = new SqlAzureRestApiClient();
                        }
                    }
                }
                return _provider;
            }
        }

        protected override string GetApiServiceEndpoint(SubscriptionAccount subscriptionAccount)
        {
            // (blairch) After reading powershell source code, management restful api actually has the ability 
            // to get sql server and sql database list.
            // But we still keep SqlServiceEndpoint field in db, it's not used now but reserved for further.
            return subscriptionAccount.ServiceEndpoint;
        }

        protected override string ApiVersion
        {
            get { return "2012-03-01"; }
        }
    }
}
