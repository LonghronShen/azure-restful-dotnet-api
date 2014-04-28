namespace Azure.Restful.Model.Deployment
{
    public class GuestAgentStatus
    {
        public string ProtocolVersion { get; set; }
        public string Timestamp { get; set; }
        public string GuestAgentVersion { get; set; }
        public string Status { get; set; }
        public FormattedMessage FormattedMessage { get; set; }
    }
}
