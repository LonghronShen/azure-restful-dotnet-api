using Azure.Restful.Model.Base;

namespace Azure.Restful.Model.WebSite
{
    public class NameValuePair : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
