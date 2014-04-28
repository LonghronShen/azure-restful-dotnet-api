namespace Azure.Restful.Model.SqlAzure
{
    public class Server
    {
        public string Name { get; set; }
        public string AdministratorLogin { get; set; }
        public string Location { get; set; }
        public string FullyQualifiedDomainName { get; set; }
        public string Version { get; set; }
    }
}
