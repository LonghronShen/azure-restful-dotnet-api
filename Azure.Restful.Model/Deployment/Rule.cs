namespace Azure.Restful.Model.Deployment
{
    public class Rule
    {
        public int Order { get; set; }
        public string Action { get; set; }
        public string RemoteSubnet { get; set; }
        public string Description { get; set; }
    }
}
