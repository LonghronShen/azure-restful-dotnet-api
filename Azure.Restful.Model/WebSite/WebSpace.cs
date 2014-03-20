using System;
using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.WebSite
{
    public class WebSpace : BaseEntity
    {
        public string AvailabilityState { get; set; }
        public string ComputeMode { get; set; }
        public int? CurrentNumberOfWorkers { get; set; }
        public string CurrentWorkerSize  { get; set; }
        public string GeoLocation { get; set; }
        public string GeoRegion { get; set; }
        public string Name { get; set; }
        public int? NumberOfWorkers { get; set; }
        public string Plan { get; set; }
        public string Status { get; set; }
        public Guid Subscription { get; set; }
        public string WorkerSize{get;set;}
    }
}
