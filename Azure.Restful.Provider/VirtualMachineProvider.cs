using Azure.Restful.Common;
using Azure.Restful.Model;
using Azure.Restful.Model.Deployment;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Restful.Provider
{
    public class VirtualMachineProvider : BaseProvider<VirtualMachine>
    {

        public VirtualMachineProvider(SubscriptionAccount subscriptionAccount)
            : base(subscriptionAccount)
        {
            _provider = ServiceManagementRestApiClient.Instance;
        }

        public override IEnumerable<VirtualMachine> GetList()
        {
            HostedServiceProvider hostedServiceProvider = new HostedServiceProvider(subscriptionAccount);
            DeploymentProvider deploymentProvider = new DeploymentProvider(subscriptionAccount);

            List<VirtualMachine> result = new List<VirtualMachine>();
            foreach (HostedService hs in hostedServiceProvider.GetList())
            {
                Deployment deployment = deploymentProvider.GetSingleBySlot(hs.ServiceName, "production");
                if (deployment != null)
                {
                    foreach (var role in deployment.RoleList.Where(v => v.RoleType == "PersistentVMRole").ToList())
                    {
                        result.AddRange(GetListByDeployment(deployment));
                    }
                }
            }
            return result;
        }

        public IEnumerable<VirtualMachine> GetListByDeployment(Deployment deployment)
        {
            foreach (var role in deployment.RoleList.Where(v => v.RoleType == "PersistentVMRole").ToList())
            {
                VirtualMachine vm = new VirtualMachine
                {
                    RoleName = role.RoleName,
                    OsVersion = role.OsVersion,
                    RoleType = role.RoleType,
                    ConfigurationSets = role.ConfigurationSets,
                    AvailabilitySetName = role.AvailabilitySetName,
                    DataVirtualHardDisks = role.DataVirtualHardDisks,
                    OSVirtualHardDisk = role.OSVirtualHardDisk,
                    RoleSize = role.RoleSize,
                    ProvisionGuestAgent = role.ProvisionGuestAgent,
                    DefaultWinRmCertificateThumbprint = role.DefaultWinRmCertificateThumbprint,
                    DeploymentId = deployment.PrivateID
                };
                yield return vm;
            }
        }

        public override bool Create(VirtualMachine entity)
        {
            //todo: generate role and create.
            throw new NotSupportedException("Please use Create(string,string,VirtualMachine) or CreateByDeployment(string,Deployment) to create virtual machine.");
        }

        public bool Create(string hostedServiceName, string deploymentName, Role vmRole)
        {
            string opName = "CreateVirtualMachineByDeployment";
            RequestInfo request = XmlProvider.CreateRequestInfo<Role>(opName, vmRole);
            request.Url = GenerateUrl(request.Url, hostedServiceName, deploymentName);
            _provider.GetResponse(subscriptionAccount, request);
            return true;
        }

        public bool CreateByDeployment(string hostedServiceName, Deployment deployment)
        {
            string opName = "CreateVirtualMachineByDeployment";
            RequestInfo request = XmlProvider.CreateRequestInfo<Deployment>(opName, deployment);
            request.Url = GenerateUrl(request.Url, hostedServiceName);
            _provider.GetResponse(subscriptionAccount, request);
            return true;
        }

        public bool CreateByXML(string hostedServiceName, string xml)
        {
            RequestInfo request = new RequestInfo();
            request.Url = GenerateUrl(request.Url, hostedServiceName);
            request.RequestBody = xml;
            request.Method = "POST";
            _provider.GetResponse(subscriptionAccount, request);
            return true;
        }
    }
}
