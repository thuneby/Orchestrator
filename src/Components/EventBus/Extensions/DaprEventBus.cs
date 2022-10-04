using Microsoft.Extensions.Logging;
using Dapr.Client;
using Core.QueueModels;
using EventBus.Abstractions;

namespace EventBus.Extensions
{
    public class DaprEventBus : IEventBus
    {
        private const string DaprPubsubName = "pubsub";

        private readonly DaprClient _dapr;
        private readonly ILogger<DaprEventBus> _logger;

        public DaprEventBus(DaprClient dapr, ILogger<DaprEventBus> logger)
        {
            _dapr = dapr;
            _logger = logger;
        }

        public async Task PublishAsync(QueueMessage queueMessage, string topicName)
        {
            _logger.LogInformation("Publishing message {queueMessage} to {PubsubName}.{TopicName}", queueMessage, DaprPubsubName, topicName);
            await _dapr.PublishEventAsync<QueueMessage>(DaprPubsubName, topicName, queueMessage);
        }
    }
}
