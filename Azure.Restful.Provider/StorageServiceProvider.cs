﻿using Azure.Restful.Model;
using Azure.Restful.Model.StorageService;
using Azure.Restful.Common;

namespace Azure.Restful.Provider
{
    public class StorageServiceProvider : BaseProvider<StorageService>
    {

        public StorageServiceProvider(SubscriptionAccount subscriptionAccount)
            : base(subscriptionAccount)
        {
            _provider = ServiceManagementRestApiClient.Instance;
        }

        public override StorageService GetSingle(string name)
        {
            string opName = "GetStorageKey";
            RequestInfo request = XmlProvider.CreateRequestInfo<StorageService>(opName, null);
            request.Url = GenerateUrl(request.Url, name);
            return _provider.GetResponseEntity<StorageService>(subscriptionAccount, request);
        }
    }
}
