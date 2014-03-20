using System;
using System.Collections.Generic;
using Azure.Restful.Model.Base;

namespace Azure.Restful.Model
{
    public class HostedServiceProperties : BaseEntity
    {
        public HostedServiceProperties()
        {
            ExtendedProperties = new List<ExtendedProperty>();
        }

        public string Description { get; set; }
        public string AffinityGroup { get; set; }
        public string Location { get; set; }
        public string Label { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModified { get; set; }
        public List<ExtendedProperty> ExtendedProperties { get; set; }
    }
}
