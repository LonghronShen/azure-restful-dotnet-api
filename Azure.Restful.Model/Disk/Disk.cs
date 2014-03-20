using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.Disk
{
    public class Disk : BaseEntity
    {
        public string AffinityGroup { get; set; }
        public AttachedTo AttachedTo { get; set; }
        public string OS { get; set; }
        public string Label { get; set; }
        public string Location { get; set; }
        public int LogicalDiskSizeInGB { get; set; }
        public string MediaLink { get; set; }
        public string Name { get; set; }
        public string SourceImageName { get; set; }
        public bool IsPremium { get; set; }
        public string PricingDetailLink { get; set; }
    }
}
