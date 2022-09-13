using Core.QueueModels;
using EventBus.Events;

namespace EventBus.Abstractions
{
    public interface IEventBus
    {
        Task PublishAsync(QueueMessage queueMessage, string topicName);

    }
}
