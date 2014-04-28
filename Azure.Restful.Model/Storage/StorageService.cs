using System.Collections.Generic;
using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.Storage
{
    public class StorageService
    {
        public string Url { get; set; }
        public string ServiceName { get; set; }
        public StorageServiceKeys StorageServiceKeys { get; set; }
        public StorageServiceProperties StorageServiceProperties { get; set; }
        public List<ExtendedProperty> ExtendedProperties { get; set; }
    }
}
