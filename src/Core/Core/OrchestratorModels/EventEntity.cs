using System.ComponentModel.DataAnnotations.Schema;
using Core.CoreModels;

namespace Core.OrchestratorModels
{
    public class EventEntity : GuidModelBase
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
                if (!string.IsNullOrWhiteSpace(ErrorMessage))
                    ErrorMessage = "Last known error: " + ErrorMessage;
            }
            EndTime = DateTime.UtcNow;
        }

        public void StartEvent()
        {
            State = EventState.Processing;
            StartTime = DateTime.UtcNow;
            ExecutionCount++;
        }

        public void AssignResult(EventEntity result)
        {
            State = result.State;
            Result = result.Result;
            ErrorMessage = result.ErrorMessage;
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
