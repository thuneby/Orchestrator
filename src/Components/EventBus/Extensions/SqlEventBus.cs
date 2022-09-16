using Core.Models;
using Core.QueueModels;
using DataAccess.DataAccess;
using EventBus.Abstractions;
using Newtonsoft.Json;

namespace EventBus.Extensions
{
    public class SqlEventBus : IEventBus
    {
        private readonly EventRepository _eventRepository;

        public SqlEventBus(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task PublishAsync(QueueMessage queueMessage, string topicName)
        {
            var payload = JsonConvert.SerializeObject(queueMessage);
            var entity = new EventEntity
            {
                TenantÍd = queueMessage.TenantÍd,
                EventType = GetEventType(topicName),
                State = EventState.New,
                ProcessState = queueMessage.ProcessState,
                Parameters = payload
            };
            await _eventRepository.AddOrUpdateEventEntity(entity);
        }

        private static EventType GetEventType(string topic)
        {
            switch (topic)
            {
                case "FileUploadedEvent":
                case "FileParsedEvent":
                case "RecordParsedEvent":
                    return EventType.FileLoad;
                default:
                    return EventType.FileLoad;
            }
        }
    }
}
