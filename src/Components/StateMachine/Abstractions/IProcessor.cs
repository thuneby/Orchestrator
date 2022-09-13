using Core.Models;

namespace StateMachine.Abstractions
{
    internal interface IProcessor
    {
        Task<EventEntity> ProcessEvent(EventEntity entity);
    }
}
