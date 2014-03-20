using System;
using System.Collections.Generic;
using Azure.Restful.Model;
using Azure.Restful.Model.Deployment;
using Azure.Restful.Common;

namespace Azure.Restful.Provider
{
    public class DeploymentProvider : BaseProvider<Deployment>
    {
        public DeploymentProvider(SubscriptionAccount subscriptionAccount)
            : base(subscriptionAccount)
        {
            _provider = ServiceManagementRestApiClient.Instance;
        }

        public override IEnumerable<Deployment> GetList()
        {
            throw new NotSupportedException("Do not support get list function.");
        }

        public override Deployment GetSingle(string name)
        {
            throw new NotSupportedException("Do not support get single with name only");
        }

        public Deployment GetSingleBySlot(string hostedServiceName, string slot)
        {
            RequestInfo request = new RequestInfo
                {
                    Url = "[service-endpoint]/[subscription-id]/services/hostedservices/{cloudservice-name}/deploymentslots/{deployment-slot}",
                    Method = "GET",
                    RequestBody = null
                };
            request.Url = GenerateUrl(request.Url, hostedServiceName, slot);
            return _provider.GetResponseEntity<Deployment>(subscriptionAccount, request);
        }

        public Deployment GetSingleByName(string hostedServiceName, string name)
        {
            RequestInfo request = new RequestInfo
                {
                    Url = "[service-endpoint]/[subscription-id]/services/hostedservices/{cloudservice-name}/deployments/{deployment-name}",
                    Method = "GET",
                    RequestBody = null
                };
            request.Url = GenerateUrl(request.Url, hostedServiceName, name);
            return _provider.GetResponseEntity<Deployment>(subscriptionAccount, request);
        }

        public override bool Create(Deployment entity)
        {
            throw new NotSupportedException("Please use DeploymentDefination intance to create deployment.");
        }

        public bool Create(string hostedServiceName, string slot, DeploymentDefination deploymentDefination)
        {
            string opName = "CreateDeployment";
            RequestInfo request = XmlProvider.CreateRequestInfo<DeploymentDefination>(opName, deploymentDefination);
            request.Url = GenerateUrl(request.Url, hostedServiceName, slot);
            _provider.GetResponse(subscriptionAccount, request);
            return true;
        }

        public override bool Delete(Deployment entity)
        {
            throw new NotSupportedException("Not support delete by deployment instance, use 'hostedservice' and 'deploymentname/slot' version.");
        }

        public bool DeleteBySlot(string hostedServiceName, string slot)
        {
            RequestInfo request = new RequestInfo
                {
                    Url = "[service-endpoint]/[subscription-id]/services/hostedservices/{cloudservice-name}/deploymentslots/{deployment-slot}",
                    Method = "DELETE",
                    RequestBody = null
                };
            request.Url = GenerateUrl(request.Url, hostedServiceName, slot);
            _provider.GetResponse(subscriptionAccount, request);
            return true;
        }

        public bool DeleteByName(string hostedServiceName, string name)
        {
            RequestInfo request = new RequestInfo
                {
                    Url = "[service-endpoint]/[subscription-id]/services/hostedservices/{cloudservice-name}/deployments/{deployment-name}",
                    Method = "DELETE",
                    RequestBody = null
                };
            request.Url = GenerateUrl(request.Url, hostedServiceName, name);
            _provider.GetResponse(subscriptionAccount, request);
            return true;
        }

        public bool UpdateDeploymentStatusBySlot(string hostedServiceName, string slot, string status)
        {
            string url = GenerateUrl("[service-endpoint]/[subscription-id]/services/hostedservices/{cloudservice-name}/deploymentslots/{deployment-slot}/?comp=status", hostedServiceName, slot);
            return UpdateDeploymentStatus(url, status);
        }

        public bool UpdateDeploymentStatusByName(string hostedServiceName, string name, string status)
        {
            string url = GenerateUrl("[service-endpoint]/[subscription-id]/services/hostedservices/{cloudservice-name}/deployments/{deployment-name}/?comp=status", hostedServiceName, name);
            return UpdateDeploymentStatus(url, status);
        }

        private bool UpdateDeploymentStatus(string url, string status)
        {
            if (status != "Running" && status != "Suspended")
            {
                throw new ApplicationException("The status can only be 'Running' or 'Suspended'");
            }
            RequestInfo request = new RequestInfo
                {
                    Url = url,
                    Method = "POST",
                    RequestBody = "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                };
            request.RequestBody += "<UpdateDeploymentStatus xmlns=\"http://schemas.microsoft.com/windowsazure\">";
            request.RequestBody += "<Status>" + status + "</Status>";
            request.RequestBody += "</UpdateDeploymentStatus>";
            _provider.GetResponse(subscriptionAccount, request);
            return true;
        }

        public override bool Update(Deployment entity)
        {
            throw new NotSupportedException("Please use function UpgradeBySlot or UpgradeByName.");
        }

        public bool UpgradeBySlot(string hostedServiceName, string slot, UpgradeDeploymentDefination defination)
        {
            string url = GenerateUrl("[service-endpoint]/[subscription-id]/services/hostedservices/{cloudservice-name}/deploymentslots/{deployment-slot}/?comp=upgrade", hostedServiceName, slot);
            return Upgrade(url, defination);
        }

        public bool UpgradeByName(string hostedServiceName, string name, UpgradeDeploymentDefination defination)
        {
            string url = GenerateUrl("[service-endpoint]/[subscription-id]/services/hostedservices/{cloudservice-name}/deployments/{deployment-name}/?comp=upgrade", hostedServiceName, name);
            return Upgrade(url, defination);
        }

        private bool Upgrade(string url, UpgradeDeploymentDefination defination)
        {
            RequestInfo request = XmlProvider.CreateRequestInfo<UpgradeDeploymentDefination>("UpgradeDeployment", defination);
            request.Url = url;
            _provider.GetResponse(subscriptionAccount, request);
            return true;
        }
    }
}
