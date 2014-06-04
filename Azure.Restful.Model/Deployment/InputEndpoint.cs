namespace Azure.Restful.Model.Deployment
{
    public class InputEndpoint
    {
        public string LoadBalancedEndpointSetName { get; set; }
        public string LocalPort { get; set; }
        public string Name { get; set; }
        public string Port { get; set; }
        public LoadBalancerProbe LoadBalancerProbe { get; set; }
        public string Protocol { get; set; }
        public string Vip { get; set; }
        public string EnableDirectServerReturn { get; set; }
        public EndpointAcl EndpointAcl { get; set; }
    }
}
