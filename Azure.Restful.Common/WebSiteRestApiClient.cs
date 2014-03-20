using System;
using Azure.Restful.Model;

namespace Azure.Restful.Common
{
    public class WebSiteRestApiClient : BaseRestApiClient
    {
        private static WebSiteRestApiClient _restApiClient;
        private static readonly object _locker = new object();

        private WebSiteRestApiClient() { }

        public WebSiteRestApiClient Instance
        {
            get
            {
                if (_restApiClient == null)
                {
                    lock(_locker)
                    {
                        if ( _restApiClient == null)
                        {
                            _restApiClient = new WebSiteRestApiClient();
                        }
                    }
                }
                return _restApiClient;
            }
        }

        protected override string GetApiServiceEndpoint(SubscriptionAccount subscriptionAccount)
        {
            throw new NotImplementedException();
        }

        protected override string ApiVersion
        {
            get { throw new NotImplementedException(); }
        }
    }
}
