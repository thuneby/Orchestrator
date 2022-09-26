using Core.CoreModels;
using Core.OrchestratorModels;
using Core.QueueModels;
using DataAccess.DataAccess;
using EventBus.Abstractions;

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
            // var payload = JsonConvert.SerializeObject(queueMessage);
            var entity = new EventEntity
            {
                TenantÍd = queueMessage.TenantÍd,
                EventType = GetEventType(topicName, queueMessage.DocumentType),
                State = EventState.New,
                ProcessState = queueMessage.ProcessState,
                DocumentType = queueMessage.DocumentType,
                Parameters = queueMessage.Id.ToString()
            };
            _eventRepository.AddOrUpdateEventEntity(entity);
        }

        private static EventType GetEventType(string topic, DocumentType documentType)
        {
            switch (topic)
            {
                case "FileUploadedEvent":
                case "FileParsedEvent":
                case "RecordParsedEvent":
                    return documentType switch
                    {
                        DocumentType.NetsOs => EventType.HandleOs,
                        DocumentType.NetsOsInfo => EventType.HandleOsInfo,
                        DocumentType.Bs601 => EventType.HandleBs601,
                        DocumentType.Bs605 => EventType.HandleBs605,
                        _ => throw new ArgumentOutOfRangeException(nameof(documentType), documentType, null)
                    };
                default:
                    return EventType.HandleOsInfo;
            }
        }
    }
}
