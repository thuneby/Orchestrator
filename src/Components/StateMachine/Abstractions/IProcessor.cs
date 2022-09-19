using Core.Models;

namespace StateMachine.Abstractions
{
    public interface IProcessor
    {
        Task<EventEntity> ProcessEvent(EventEntity entity);
    }
}
