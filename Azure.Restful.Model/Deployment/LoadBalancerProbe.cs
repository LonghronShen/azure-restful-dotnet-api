namespace Azure.Restful.Model.Deployment
{
    public class LoadBalancerProbe
    {
        public string Path { get; set; }
        public string Port { get; set; }
        public string Protocol { get; set; }
        public string IntervalInSeconds { get; set; }
        public string TimeoutInSeconds { get; set; }
    }
}
