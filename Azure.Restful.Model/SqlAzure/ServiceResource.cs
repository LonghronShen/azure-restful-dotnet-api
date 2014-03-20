using System;

namespace Azure.Restful.Model.SqlAzure
{
    public class ServiceResource
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string SelfLink { get; set; }
        public string ParentLink { get; set; }
        public int Id { get; set; }
        public string Edition { get; set; }
        public int? MaxSizeGB { get; set; }
        public string CollationName { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool IsFederationRoot { get; set; }
        public bool IsSystemObject { get; set; }
        public decimal? SizeMB { get; set; }
        public long MaxSizeBytes { get; set; }
        public Guid ServiceObjectiveId { get; set; }
        public Guid AssignedServiceObjectiveId { get; set; }
        public string ServiceObjectiveAssignmentState { get; set; }
        public string ServiceObjectiveAssignmentStateDescription { get; set; }
        public string ServiceObjectiveAssignmentErrorCode { get; set; }
        public string ServiceObjectiveAssignmentErrorDescription { get; set; }
        public DateTime? ServiceObjectiveAssignmentSuccessDate { get; set; }
        public DateTime? RecoveryPeriodStartDate { get; set; }
        public bool IsSuspended { get; set; }
    }
}