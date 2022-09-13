using Core.Models;

namespace StateMachine.BusinessLogic
{
    internal class ProcessHelper
    {
        public static EventEntity UpdateProcessResult(EventEntity entity, EventState state = EventState.Completed)
        {
            entity.State = state;
            if (state == EventState.Completed)
            {
                if (!string.IsNullOrWhiteSpace(entity.ErrorMessage))
                    entity.ErrorMessage = "Last known error: " + entity.ErrorMessage;
            }
            entity.EndTime = DateTime.UtcNow;
            return entity;
        }

        public static EventEntity StartEvent(EventEntity entity)
        {
            entity.State = EventState.Processing;
            entity.StartTime = DateTime.UtcNow;
            entity.ExecutionCount++;
            return entity;
        }
    }
}
