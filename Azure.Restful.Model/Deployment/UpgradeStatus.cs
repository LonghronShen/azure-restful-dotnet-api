namespace Azure.Restful.Model.Deployment
{
    public class UpgradeStatus
    {
        public string UpgradeType { get; set; }
        public string CurrentUpgradeDomainState { get; set; }
        public string CurrentUpgradeDomain { get; set; }
    }
}
