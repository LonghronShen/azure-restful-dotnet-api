using System.Collections.Generic;
using Azure.Restful.Model;
using Azure.Restful.Model.WebSite;
using Azure.Restful.Common;

namespace Azure.Restful.Provider
{
    public class WebSiteProvider : BaseProvider<WebSite>
    {
        private string _webSpaceName;
        public WebSiteProvider(SubscriptionAccount subscriptionAccount, string webSpaceName)
            : base(subscriptionAccount)
        {
            _provider = ServiceManagementRestApiClient.Instance;
            _webSpaceName = webSpaceName;
        }
        public override IEnumerable<WebSite> GetList()
        {
            string opName = "ListWebSite";
            RequestInfo request = XmlProvider.CreateRequestInfo<WebSite>(opName, null);
            request.Url = GenerateUrl(request.Url, _webSpaceName);
            return _provider.GetResponseEntities<WebSite>(subscriptionAccount, request);
        }
    }
}
