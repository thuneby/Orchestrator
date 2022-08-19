namespace Orchestrator.Core.Models
{
    public class EventEntity: GuidModelBase
    {
        public long FlowId { get; set; }
        public EventType EventType { get; set; }
        public EventState State { get; set; }
        public ProcessState ProcessState { get; set; }
        public string Parameters { get; set; }
        public string Result { get; set; }
        public string ErrorMessage { get; set; }
        public short ExecutionCount { get; set; }
        public short Priority { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
