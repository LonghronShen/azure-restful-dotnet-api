using System;
namespace Azure.Restful.Model.Deployment
{
    public class PersistentVMDowntime
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; }
    }
}
