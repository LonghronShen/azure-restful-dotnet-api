using System;

namespace Azure.Restful.Model.OSImage
{
    public class OSImage
    {
        public string AffinityGroup { get; set; }
        public string Category { get; set; }
        public string Label { get; set; }
        public string Location { get; set; }
        public int LogicalSizeInGB { get; set; }
        public string MediaLink { get; set; }
        public string Name { get; set; }
        public string OS { get; set; }
        public string Eula { get; set; }
        public string Description { get; set; }
        public string ImageFamily { get; set; }
        public bool ShowInGui { get; set; }
        public DateTime? PublishedDate { get; set; }
        public bool IsPremium { get; set; }
        public string IconUri { get; set; }
        public string PrivacyUri { get; set; }
        public string RecommendedVMSize { get; set; }
        public string PublisherName { get; set; }
        public string PricingDetailLink { get; set; }
        public string SmallIconUri { get; set; }
    }
}
