﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Azure.Restful.Model {
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class XmlDefResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal XmlDefResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Azure.Restful.Model.XmlDefResource", typeof(XmlDefResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;CreateAffinityGroup Url=&quot;[service-endpoint]/[subscription-id]/affinitygroups&quot; Method=&quot;POST&quot;  xmlns=&quot;http://schemas.microsoft.com/windowsazure&quot;&gt;
        ///    &lt;Name&gt;affinity-group-name&lt;/Name&gt;
        ///    &lt;Label&gt;base64-encoded-affinity-group-label&lt;/Label&gt;
        ///    &lt;Description&gt;affinity-group-description&lt;/Description&gt;
        ///    &lt;Location&gt;location&lt;/Location&gt;
        ///  &lt;/CreateAffinityGroup&gt;.
        /// </summary>
        public static string CreateAffinityGroup {
            get {
                return ResourceManager.GetString("CreateAffinityGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;CreateDeployment Url=&quot;[service-endpoint]/[subscription-id]/services/hostedservices/{cloudservice-name}/deploymentslots/{deployment-slot}&quot; Method=&quot;POST&quot; xmlns=&quot;http://schemas.microsoft.com/windowsazure&quot;&gt;
        ///  &lt;Name&gt;deployment-name&lt;/Name&gt;
        ///  &lt;PackageUrl&gt;package-url-in-blob-storage&lt;/PackageUrl&gt;
        ///  &lt;Label&gt;base64-encoded-deployment-label&lt;/Label&gt;
        ///  &lt;Configuration&gt;base64-encoded-configuration-file&lt;/Configuration&gt;
        ///  &lt;StartDeployment&gt;true|false&lt;/StartDeployment&gt;
        ///  &lt;TreatWarn [rest of string was truncated]&quot;;.
        /// </summary>
        public static string CreateDeployment {
            get {
                return ResourceManager.GetString("CreateDeployment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;CreateHostedService Url=&quot;[service-endpoint]/[subscription-id]/services/hostedservices&quot; Method=&quot;POST&quot; xmlns=&quot;http://schemas.microsoft.com/windowsazure&quot;&gt;
        ///  &lt;ServiceName&gt;service-name&lt;/ServiceName&gt;
        ///  &lt;Label From=&quot;HostedServiceProperties.Label&quot;&gt;base64-encoded-service-label&lt;/Label&gt;
        ///  &lt;Description From=&quot;HostedServiceProperties.Description&quot;&gt;description&lt;/Description&gt;
        ///  &lt;Location From=&quot;HostedServiceProperties.Location&quot;&gt;location&lt;/Location&gt;
        ///  &lt;AffinityGroup From=&quot;HostedServ [rest of string was truncated]&quot;;.
        /// </summary>
        public static string CreateHostedService {
            get {
                return ResourceManager.GetString("CreateHostedService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;CreateStorageServiceInput Url=&quot;[service-endpoint]/[subscription-id]/services/storageservices&quot; Method=&quot;POST&quot; xmlns=&quot;http://schemas.microsoft.com/windowsazure&quot;&gt;
        ///  &lt;ServiceName&gt;service-name&lt;/ServiceName&gt;
        ///  &lt;Description From=&quot;StorageServiceProperties.Description&quot;&gt;service-description&lt;/Description&gt;
        ///  &lt;Label From=&quot;StorageServiceProperties.Label&quot;&gt;base64-encoded-label&lt;/Label&gt;
        ///  &lt;AffinityGroup From=&quot;StorageServiceProperties.AffinityGroup&quot;&gt;affinity-group-name&lt;/AffinityGroup [rest of string was truncated]&quot;;.
        /// </summary>
        public static string CreateStorageService {
            get {
                return ResourceManager.GetString("CreateStorageService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;PersistentVMRole Url=&quot;[service-endpoint]/[subscription-id]/services/hostedservices/{cloudservice-name}/deploymentslots/{deployment-slot}/{deployment-name}/roles&quot; Method=&quot;POST&quot; xmlns=&quot;http://schemas.microsoft.com/windowsazure&quot;&gt;
        ///  &lt;RoleName&gt;name-of-the-virtual-machine&lt;/RoleName&gt;
        ///  &lt;RoleType&gt;PersistentVMRole&lt;/RoleType&gt;
        ///  &lt;ConfigurationSets&gt;
        ///    &lt;ConfigurationSet&gt;
        ///      &lt;ConfigurationSetType&gt;WindowsProvisioningConfiguration&lt;/ConfigurationSetType&gt;
        ///        &lt;ComputerN [rest of string was truncated]&quot;;.
        /// </summary>
        public static string CreateVirtualMachine {
            get {
                return ResourceManager.GetString("CreateVirtualMachine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Deployment xmlns=&quot;http://schemas.microsoft.com/windowsazure&quot; xmlns:i=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; Url=&quot;[service-endpoint]/[subscription-id]/services/hostedservices/{cloudservice-name}/deployments&quot; Method=&quot;POST&quot;&gt;
        ///  &lt;Name&gt;name-of-deployment&lt;/Name&gt;
        ///  &lt;DeploymentSlot&gt;deployment-environment&lt;/DeploymentSlot&gt;
        ///  &lt;Label&gt;identifier-of-deployment&lt;/Label&gt;      
        ///  &lt;RoleList&gt;
        ///    &lt;Role&gt;
        ///      &lt;RoleName&gt;name-of-the-virtual-machine&lt;/RoleName&gt;
        ///      &lt;RoleType&gt;PersistentVMRole&lt;/RoleType&gt;      
        ///      &lt; [rest of string was truncated]&quot;;.
        /// </summary>
        public static string CreateVirtualMachineByDeployment {
            get {
                return ResourceManager.GetString("CreateVirtualMachineByDeployment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;NetworkConfiguration Url=&quot;[service-endpoint]/[subscription-id]/services/networking/media&quot; Method=&quot;POST&quot; xmlns=&quot;http://schemas.microsoft.com/ServiceHosting/2011/07/NetworkConfiguration&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; &gt;
        ///  &lt;VirtualNetworkConfiguration&gt;
        ///    &lt;Dns&gt;
        ///      &lt;DnsServers&gt;
        ///        &lt;DnsServer name=&quot;dns-server-name&quot; IPAddress=&quot;IPV4-address-of-the-server&quot;/&gt;
        ///      &lt;/DnsServers&gt;
        ///    &lt;/Dns&gt;
        ///    &lt;LocalNetworkSites&gt;
        ///      &lt;LocalNetworkSite [rest of string was truncated]&quot;;.
        /// </summary>
        public static string CreateVirtualNetworkSite {
            get {
                return ResourceManager.GetString("CreateVirtualNetworkSite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/affinitygroups/{name}&quot; Method=&quot;DELETE&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string DeleteAffinityGroup {
            get {
                return ResourceManager.GetString("DeleteAffinityGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/services/hostedservices/{service-name}&quot; Method=&quot;DELETE&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string DeleteHostedService {
            get {
                return ResourceManager.GetString("DeleteHostedService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/affinitygroups/{name}&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string GetAffinityGroup {
            get {
                return ResourceManager.GetString("GetAffinityGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/services/hostedservices/{service-name}&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string GetHostedService {
            get {
                return ResourceManager.GetString("GetHostedService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/services/storageservices/{service-name}/keys&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string GetStorageKey {
            get {
                return ResourceManager.GetString("GetStorageKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string GetSubscription {
            get {
                return ResourceManager.GetString("GetSubscription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/affinitygroups&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string ListAffinityGroup {
            get {
                return ResourceManager.GetString("ListAffinityGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/services/disks&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string ListDisk {
            get {
                return ResourceManager.GetString("ListDisk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/services/hostedservices&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string ListHostedService {
            get {
                return ResourceManager.GetString("ListHostedService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/services/images&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string ListOSImage {
            get {
                return ResourceManager.GetString("ListOSImage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/services/sqlservers/servers&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string ListServer {
            get {
                return ResourceManager.GetString("ListServer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]//services/sqlservers/servers/{name}/databases?contentview=generic&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string ListServiceResource {
            get {
                return ResourceManager.GetString("ListServiceResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/services/storageservices&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string ListStorageService {
            get {
                return ResourceManager.GetString("ListStorageService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/services/networking/virtualnetwork&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string ListVirtualNetworkSite {
            get {
                return ResourceManager.GetString("ListVirtualNetworkSite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/services/webspaces/{webspacename}/sites&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string ListWebSite {
            get {
                return ResourceManager.GetString("ListWebSite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Empty Url=&quot;[service-endpoint]/[subscription-id]/services/webspaces&quot; Method=&quot;GET&quot;&gt;&lt;/Empty&gt;.
        /// </summary>
        public static string ListWebSpace {
            get {
                return ResourceManager.GetString("ListWebSpace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;UpdateAffinityGroup Url=&quot;[service-endpoint]/[subscription-id]/affinitygroups/{name}&quot; Mehod=&quot;PUT&quot;  xmlns=&quot;http://schemas.microsoft.com/windowsazure&quot;&gt;
        ///      &lt;Label&gt;base64-encoded-affinity-group-label&lt;/Label&gt;
        ///      &lt;Description&gt;affinity-group-description&lt;/Description&gt;
        ///&lt;/UpdateAffinityGroup&gt;.
        /// </summary>
        public static string UpdateAffinityGroup {
            get {
                return ResourceManager.GetString("UpdateAffinityGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;UpdateHostedService From=&quot;HostedServiceProperties&quot; Url=&quot;[service-endpoint]/[subscription-id]/services/hostedservices/{service-name}&quot; Method=&quot;PUT&quot; xmlns=&quot;http://schemas.microsoft.com/windowsazure&quot;&gt;
        ///  &lt;Label&gt;base64-encoded-service-label&lt;/Label&gt;
        ///  &lt;Description&gt;description&lt;/Description&gt;
        ///  &lt;ExtendedProperties&gt;
        ///    &lt;ExtendedProperty&gt;
        ///      &lt;Name&gt;property-name&lt;/Name&gt;
        ///      &lt;Value&gt;property-value&lt;/Value&gt;
        ///    &lt;/ExtendedProperty&gt;
        ///  &lt;/ExtendedProperties&gt;
        ///&lt;/UpdateHostedS [rest of string was truncated]&quot;;.
        /// </summary>
        public static string UpdateHostedService {
            get {
                return ResourceManager.GetString("UpdateHostedService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;UpgradeDeployment xmlns=&quot;http://schemas.microsoft.com/windowsazure&quot; Method=&quot;POST&quot;&gt;
        ///  &lt;Mode&gt;auto|manual&lt;/Mode&gt;
        ///  &lt;PackageUrl&gt;url-to-package&lt;/PackageUrl&gt;
        ///  &lt;Configuration&gt;base64-encoded-config-file&lt;/Configuration&gt;
        ///  &lt;Label&gt;base-64-encoded-label&lt;/Label&gt;
        ///  &lt;RoleToUpgrade&gt;role-name&lt;/RoleToUpgrade&gt;
        ///  &lt;Force&gt;true|false&lt;/Force&gt;
        ///  &lt;ExtendedProperties&gt;
        ///    &lt;ExtendedProperty&gt;
        ///      &lt;Name&gt;property-name&lt;/Name&gt;
        ///      &lt;Value&gt;property-value&lt;/Value&gt;
        ///    &lt;/ExtendedProperty&gt; [rest of string was truncated]&quot;;.
        /// </summary>
        public static string UpgradeDeployment {
            get {
                return ResourceManager.GetString("UpgradeDeployment", resourceCulture);
            }
        }
    }
}
