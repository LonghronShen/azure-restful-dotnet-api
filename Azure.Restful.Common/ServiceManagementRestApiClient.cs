

using Azure.Restful.Model;
namespace Azure.Restful.Common
{
    public class ServiceManagementRestApiClient : BaseRestApiClient
    {
        private static ServiceManagementRestApiClient _managementRestApiClient;
        private static readonly object _locker = new object();

        private ServiceManagementRestApiClient() { }

        public static ServiceManagementRestApiClient Instance
        {
            get
            {
                if (_managementRestApiClient == null)
                {
                    lock (_locker)
                    {
                        if (_managementRestApiClient == null)
                        {
                            _managementRestApiClient = new ServiceManagementRestApiClient();
                        }
                    }
                }
                return _managementRestApiClient;
            }
        }

        protected override string GetApiServiceEndpoint(SubscriptionAccount subscriptionAccount)
        {
            return subscriptionAccount.ServiceEndpoint;
        }

        protected override string ApiVersion
        {
            get { return "2014-04-01"; }
        }
    }
}
