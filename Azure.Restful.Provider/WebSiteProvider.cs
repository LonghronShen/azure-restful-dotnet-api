using System.Collections.Generic;
using Azure.Restful.Model;
using Azure.Restful.Model.WebSite;
using Azure.Restful.Common;

namespace Azure.Restful.Provider
{
    public class WebSiteProvider : BaseProvider<WebSite>
    {
        private string webSpaceName;
        public WebSiteProvider(SubscriptionAccount subscriptionAccount, string webSpaceName)
            : base(subscriptionAccount)
        {
            this.webSpaceName = webSpaceName;
        }

        public WebSiteProvider()
            : this(null, null)
        {

        }

        public string WebSpaceName
        {
            get { return webSpaceName; }
            set { webSpaceName = value; }
        }

        public override IEnumerable<WebSite> GetList()
        {
            string opName = "ListWebSite";
            RequestInfo request = XmlProvider.CreateRequestInfo<WebSite>(opName, null);
            request.Url = GenerateUrl(request.Url, webSpaceName);
            return provider.GetResponseEntities<WebSite>(subscriptionAccount, request);
        }
    }
}
