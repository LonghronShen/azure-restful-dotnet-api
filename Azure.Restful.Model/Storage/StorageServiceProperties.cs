using System;
using System.Collections.Generic;

namespace Azure.Restful.Model.Storage
{
    public class StorageServiceProperties
    {
        public string Description { get; set; }
        public string Location { get; set; }
        public string AffinityGroup { get; set; }
        public string Label { get; set; }
        public string Status { get; set; }
        public List<string> Endpoints { get; set; }
        public bool GeoReplicationEnabled { get; set; }
        public string GeoPrimaryRegion { get; set; }
        public string StatusOfPrimary { get; set; }
        public DateTime? LastGeoFailoverTime { get; set; }
        public string GeoSecondaryRegion { get; set; }
        public string StatusOfSecondary { get; set; }
        public DateTime CreationTime { get; set; }
        public string CustomDomains { get; set; }
        public bool SecondaryReadEnabled { get; set; }
        public List<string> SecondaryEndpoints { get; set; }
    }
}
