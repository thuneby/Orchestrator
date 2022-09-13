using System.Text;
using Core.QueueModels;
using EventBus.Abstractions;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace EventBus.Extensions
{
    public class RabbitMqEventBus: IEventBus
    {
        public async Task PublishAsync(QueueMessage queueMessage, string topicName)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: topicName,
                    type: "topic");

                var routingKey = "anonymous.info";
                var messageJson = JsonConvert.SerializeObject(queueMessage);
                var body = Encoding.UTF8.GetBytes(messageJson);
                channel.BasicPublish(exchange: topicName, routingKey: routingKey, basicProperties: null, body: body);
            }
        }
    }
}
