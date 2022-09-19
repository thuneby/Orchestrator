using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class EventEntity: GuidModelBase
    {
        public EventEntity()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public void UpdateProcessResult(EventState state = EventState.Completed)
        {
            State = state;
            if (state == EventState.Completed)
            {
                if (!string.IsNullOrWhiteSpace(this.ErrorMessage))
                    this.ErrorMessage = "Last known error: " + this.ErrorMessage;
            }
            this.EndTime = DateTime.UtcNow;
        }

        public void StartEvent()
        {
            State = EventState.Processing;
            StartTime = DateTime.UtcNow;
            ExecutionCount++;
        }

        public long FlowId { get; set; }
        public EventType EventType { get; set; }
        public EventState State { get; set; }
        public ProcessState ProcessState { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Parameters { get; set; }
        public string Result { get; set; }
        public string ErrorMessage { get; set; }
        public short ExecutionCount { get; set; }
        public short Priority { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }


        [ForeignKey("FlowId")]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Flow Flow { get; set; }
    }
}
