using System;
using System.Collections.Generic;
using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.WebSite
{
    public class Certificate : BaseEntity
    {
        public DateTime ExpirationDate { get; set; }
        public string FriendlyName { get; set; }
        public List<string> HostNames { get; set; }
        public DateTime IssueDate { get; set; }
        public string Issuer { get; set; }
        public string Password { get; set; }
        public string PfxBlob { get; set; }
        public string SelfLink { get; set; }
        public string SiteName { get; set; }
        public string SubjectName { get; set; }
        public string Thumbprint { get; set; }
        public Boolean ToDelete { get; set; }
        public Boolean Valid { get; set; }
    }
}
