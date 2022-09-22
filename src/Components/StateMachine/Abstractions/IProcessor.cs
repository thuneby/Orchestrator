using Core.OrchestratorModels;

namespace StateMachine.Abstractions
{
    public interface IProcessor
    {
        Task<EventEntity> ProcessEvent(EventEntity entity);
    }
}
