using EventBus.Abstractions;
using StackExchange.Redis;
using Utilities.BackgroundServices;

namespace EventBus.Handlers
{
    public class RedisTopicSubscriptionHandler: IScopedProcessingService
    {
        private const string RedisConnectionString = "localhost:6379"; 
        private readonly IIntegrationEventHandler _eventHandler;

        public RedisTopicSubscriptionHandler(IIntegrationEventHandler eventHandler)
        {
            _eventHandler = eventHandler;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            using var connection = ConnectionMultiplexer.Connect(RedisConnectionString);
            var (topicName, subscriptionName) = _eventHandler.GetTopicAndSubscription();
            var pubsub = connection.GetSubscriber();
            await pubsub.SubscribeAsync(topicName, (topicName, message)
                => _eventHandler.Handle(message));

        }

    }
}
