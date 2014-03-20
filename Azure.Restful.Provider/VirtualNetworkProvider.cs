using System;
using Azure.Restful.Model;
using Azure.Restful.Common;
using System.Xml;
using Azure.Restful.Model.Networking;

namespace Azure.Restful.Provider
{
    public class VirtualNetworkProvider : BaseProvider<VirtualNetworkSite>
    {
        public VirtualNetworkProvider(SubscriptionAccount subscriptionAccount)
            : base(subscriptionAccount)
        {
            _provider = ServiceManagementRestApiClient.Instance;
        }

        public string GetNetworkConfiguration()
        {
            RequestInfo request = new RequestInfo();
            Guid subscriptionId = subscriptionAccount.SubscriptionId;
            request.Url = "https://management.core.windows.net/[subscription-id]/services/networking/media";
            request.Method = "GET";
            return _provider.GetResponse(subscriptionAccount, request);
        }

        private string GenerateCreateXML(VirtualNetworkSite virtualNetworkSite)
        {
            XmlDocument doc = new XmlDocument();
            string existingVNetConfig = GetNetworkConfiguration();
            XmlNode DNS = null;
            XmlNode DNSServerList = null;
            XmlNode LocalNetworkSites = null;
            XmlNode VirtualNetworkSites = null;
            if (!string.IsNullOrEmpty(existingVNetConfig))
            {
                doc.LoadXml(existingVNetConfig);
                XmlNode root = doc.DocumentElement;
                //string XmlNameSpaceUri = root.NamespaceURI;
                //XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                //nsmgr.AddNamespace("space", XmlNameSpaceUri);

                XmlNode VirtualNetworkConfiguration = doc.LastChild.FirstChild;
                var list = VirtualNetworkConfiguration.ChildNodes;
                foreach (XmlNode node in list)
                {
                    if (node.Name.Equals("Dns"))
                    {
                        DNS = node;
                    }
                    else if (node.Name.Equals("LocalNetworkSites"))
                    {
                        LocalNetworkSites = node;
                    }
                    else if (node.Name.Equals("VirtualNetworkSites"))
                    {
                        VirtualNetworkSites = node;
                    }
                }

                // DNS = VirtualNetworkConfiguration.SelectNodes("//space:Dns", nsmgr)[0];
                //LocalNetworkSites = VirtualNetworkConfiguration.SelectNodes("//space:LocalNetworkSites", nsmgr)[0];
                //VirtualNetworkSites = VirtualNetworkConfiguration.SelectNodes("//space:VirtualNetworkSites", nsmgr)[0];

                if ((virtualNetworkSite.Dns != null) && (string.IsNullOrEmpty(DNS.LastChild.Name)))
                {
                    DNSServerList = doc.CreateElement("DnsServers");
                    DNS.AppendChild(DNSServerList);
                }
            }
            else
            {
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);

                XmlNode NetworkConfiguration = doc.CreateElement("NetworkConfiguration");
                XmlAttribute xmlns = doc.CreateAttribute("xmlns");
                xmlns.Value = "http://schemas.microsoft.com/ServiceHosting/2011/07/NetworkConfiguration";
                NetworkConfiguration.Attributes.Append(xmlns);
                XmlAttribute xmlnsXsi = doc.CreateAttribute("xmlns:xsi");
                xmlnsXsi.Value = "http://www.w3.org/2001/XMLSchema-instance";
                NetworkConfiguration.Attributes.Append(xmlnsXsi);
                doc.AppendChild(NetworkConfiguration);

                XmlNode VirtualNetworkConfiguration = doc.CreateElement("VirtualNetworkConfiguration");

                DNS = doc.CreateElement("Dns");
                if (virtualNetworkSite.Dns != null)
                {
                    DNSServerList = doc.CreateElement("DnsServers");
                    DNS.AppendChild(DNSServerList);
                }

                VirtualNetworkConfiguration.AppendChild(DNS);
                VirtualNetworkSites = doc.CreateElement("VirtualNetworkSites");
                VirtualNetworkConfiguration.AppendChild(VirtualNetworkSites);
                NetworkConfiguration.AppendChild(VirtualNetworkConfiguration);
            }

            if (virtualNetworkSite.Dns != null)
            {
                foreach (var DnsServer in virtualNetworkSite.Dns.DnsServers)
                {
                    XmlNode DnsServerNode = doc.CreateElement("DnsServers");
                    XmlAttribute name = doc.CreateAttribute("name");
                    name.Value = DnsServer.Name;
                    DnsServerNode.Attributes.Append(name);
                    XmlAttribute IPAddress = doc.CreateAttribute("IPAddress");
                    IPAddress.Value = DnsServer.Address;
                    DnsServerNode.Attributes.Append(IPAddress);
                    DNSServerList.AppendChild(DnsServerNode);
                }
            }

            XmlNode VirtualNetworkSite = doc.CreateElement("VirtualNetworkSite");
            XmlAttribute vNetname = doc.CreateAttribute("name");
            vNetname.Value = virtualNetworkSite.Name;
            VirtualNetworkSite.Attributes.Append(vNetname);
            XmlAttribute vNetAffinityGroup = doc.CreateAttribute("AffinityGroup");
            vNetAffinityGroup.Value = virtualNetworkSite.AffinityGroup;
            VirtualNetworkSite.Attributes.Append(vNetAffinityGroup);

            //XmlNode vNetLabel = doc.CreateElement("Label");
            //vNetLabel.InnerText = virtualNetworkSite.Label.ToString();
            //VirtualNetworkSite.AppendChild(vNetLabel);

            if (virtualNetworkSite.AddressSpace != null)
            {
                XmlNode AddressSpace = doc.CreateElement("AddressSpace");
                foreach (var addressPrefix in virtualNetworkSite.AddressSpace.AddressPrefixes)
                {
                    XmlNode vNetAddressPrefix = doc.CreateElement("AddressPrefix");
                    vNetAddressPrefix.InnerText = addressPrefix;
                    AddressSpace.AppendChild(vNetAddressPrefix);
                }
                VirtualNetworkSite.AppendChild(AddressSpace);
            }

            if (virtualNetworkSite.Subnets != null)
            {
                XmlNode Subnets = doc.CreateElement("Subnets");
                foreach (var subnet in virtualNetworkSite.Subnets)
                {
                    XmlNode vNetSubnet = doc.CreateElement("Subnet");
                    XmlAttribute subnetName = doc.CreateAttribute("name");
                    subnetName.Value = subnet.Name;
                    vNetSubnet.Attributes.Append(subnetName);
                    XmlNode subnetAddress = doc.CreateElement("AddressPrefix");
                    subnetAddress.InnerText = subnet.AddressPrefix;
                    vNetSubnet.AppendChild(subnetAddress);
                    Subnets.AppendChild(vNetSubnet);
                }
                VirtualNetworkSite.AppendChild(Subnets);
            }

            if (virtualNetworkSite.Gateway != null)
            {
                XmlNode Gateway = doc.CreateElement("Gateway");
                XmlAttribute profile = doc.CreateAttribute("profile");
                profile.Value = virtualNetworkSite.Gateway.Profile;
                Gateway.Attributes.Append(profile);

                if (virtualNetworkSite.Gateway.VPNClientAddressPool.AddressPrefixes.Count > 0)
                {
                    XmlNode VPNClientAddressPool = doc.CreateElement("VPNClientAddressPool");
                    foreach (var addressPrefix in virtualNetworkSite.Gateway.VPNClientAddressPool.AddressPrefixes)
                    {
                        XmlNode VPNAddressPrefix = doc.CreateElement("AddressPrefix");
                        VPNAddressPrefix.InnerText = addressPrefix;
                        VPNClientAddressPool.AppendChild(VPNAddressPrefix);
                    }
                    Gateway.AppendChild(VPNClientAddressPool);
                }
                VirtualNetworkSite.AppendChild(Gateway);
            }
            VirtualNetworkSites.AppendChild(VirtualNetworkSite);

            XmlNode rootNode = doc.DocumentElement;
            string xml = rootNode.OuterXml.Replace("xmlns=\"\"", "");
            return xml;
        }
        
        private string GenerateDeleteXml(string name)
        {
            XmlDocument doc = new XmlDocument();
            string existingVNetConfig = GetNetworkConfiguration();
            if (!string.IsNullOrEmpty(existingVNetConfig))
            {
                doc.LoadXml(existingVNetConfig);
                XmlNode root = doc.DocumentElement;
                XmlNode VirtualNetworkConfiguration = doc.LastChild.FirstChild;
                string XmlNameSpaceUri = root.NamespaceURI;
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("space", XmlNameSpaceUri);
                XmlNode VirtualNetworkSites = VirtualNetworkConfiguration.SelectNodes("//space:VirtualNetworkSites", nsmgr)[0];
                XmlNode DeletedNode = null;
                foreach (XmlNode node in VirtualNetworkSites)
                {
                    XmlAttributeCollection attrs = node.Attributes;
                    foreach (XmlAttribute at in attrs)
                    {
                        if (at.Name.Equals("name") && at.Value.Equals(name))
                        {
                            DeletedNode = node;
                            break;
                        }
                    }
                }
                VirtualNetworkSites.RemoveChild(DeletedNode);
                XmlNode rootNode = doc.DocumentElement;
                string xml = rootNode.OuterXml.Replace("xmlns=\"\"", "");
                return xml;
            }
            else
            {
                return string.Empty;
            }
        }

        public bool CreateByXML(VirtualNetworkSite virtualNetworkSite)
        {
            try
            {
                RequestInfo request = new RequestInfo();
                Guid subscriptionId = subscriptionAccount.SubscriptionId;
                string xml = GenerateCreateXML(virtualNetworkSite);
                request.Url = "https://management.core.windows.net/[subscription-id]/services/networking/media";
                request.RequestBody = xml;
                request.Method = "PUT";
                if(!string.IsNullOrEmpty(xml))
                {
                    _provider.GetResponse(subscriptionAccount, request, "text/plain");
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch
            {
                return false;
            }
        }

        public override bool Delete(string name)
        {
            try
            {
                RequestInfo request = new RequestInfo();
                Guid subscriptionId = subscriptionAccount.SubscriptionId;
                string xml = GenerateDeleteXml(name);
                request.Url = "https://management.core.windows.net/[subscription-id]/services/networking/media";
                request.RequestBody = xml;
                request.Method = "PUT";
                if (!string.IsNullOrEmpty(xml))
                {
                    _provider.GetResponse(subscriptionAccount, request, "text/plain");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
             
        }
    }
}
