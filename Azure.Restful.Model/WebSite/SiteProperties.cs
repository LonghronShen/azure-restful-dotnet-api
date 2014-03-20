using System.Collections.Generic;
using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.WebSite
{
    public class SiteProperties:BaseEntity
    {
        public List<NameValuePair> AppSettings{get;set;}
        public List<NameValuePair> Metadata { get; set; }
        public List<NameValuePair> Properties { get; set; }
    }
}
