namespace Azure.Restful.Model.Deployment
{
    public class InstanceEndpoint
    {
        public string Name { get; set; }
        public string Vip { get; set; }
        public string PublicPort { get; set; }
        public string LocalPort { get; set; }
        public string Protocol { get; set; }
    }
}
