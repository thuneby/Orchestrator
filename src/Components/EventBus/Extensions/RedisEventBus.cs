using Core.QueueModels;
using EventBus.Abstractions;
using EventBus.Events;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using StackExchange.Redis;

namespace EventBus.Extensions
{
    public class RedisEventBus : IEventBus
    {
        private const string RedisConnectionString = "localhost:6379";
        private readonly ConnectionMultiplexer _connection;
        private readonly ILogger<RedisEventBus> _logger;

        public RedisEventBus(ILogger<RedisEventBus> logger)
        {
            _connection = ConnectionMultiplexer.Connect(RedisConnectionString);
            _logger = logger;
        }

        public async Task PublishAsync(QueueMessage queueMessage, string topicName)
        {
            var pubsub = _connection.GetSubscriber();
            var messageJson = JsonConvert.SerializeObject(queueMessage, new StringEnumConverter());
            await pubsub.PublishAsync(topicName, messageJson);
        }


    }
}
