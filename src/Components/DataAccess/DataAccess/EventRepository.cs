using Core.CoreModels;
using Core.OrchestratorModels;
using DataAccess.Models;
using Microsoft.Extensions.Logging;

namespace DataAccess.DataAccess
{
    public class EventRepository : GuidRepositoryBase<EventEntity>
    {
        private readonly OrchestratorContext _context;
        public EventRepository(OrchestratorContext context, ILogger<EventRepository> logger) : base(context, logger)
        {
            _context = context;
        }

        public void AddOrUpdateEventEntity(EventEntity eventEntity)
        {
            var existing = _context.EventEntity.FirstOrDefault(x => x.Id == eventEntity.Id);
            if (existing != null)
            {
                existing = eventEntity;
                Update(existing);
            }
            else
            {
                if ( !_context.EventEntity.Any(x => x.FlowId == eventEntity.FlowId && x.ProcessState == eventEntity.ProcessState))
                    AddEvent(eventEntity);
            }

        }

        public void AddEvent(EventEntity eventEntity)
        {
            if (eventEntity.FlowId == 0)
            {
                var flow = new Flow
                {
                    CreatedDate = eventEntity.CreatedDate
                };
                _context.Add(flow);
                eventEntity.Flow = flow;
            }
            Add(eventEntity);
        }

        public EventEntity AddOrGetEventFromFileName(long tenantId, string fileName, EventType eventType)
        {
            var existing = _context.EventEntity
                .FirstOrDefault(x => x.TenantÍd == tenantId && x.ProcessState == ProcessState.Receive && x.EventType == eventType &&
                                     !string.IsNullOrWhiteSpace(x.Parameters) && x.Parameters == fileName);
            if (existing != null && existing.State != EventState.Completed)
                return existing;
            var documentType = GetDocumentType(eventType);
            var eventEntity = new EventEntity
            {
                EventType = eventType,
                TenantÍd = tenantId,
                ProcessState = ProcessState.Receive,
                Parameters = fileName,
                DocumentType = documentType
            };
            AddEvent(eventEntity);
            return eventEntity;
        }

        public EventEntity GetNextEvent(long flowId)
        {
            var flowEvents = GetEventFlow(flowId);
            var nextEvent = flowEvents.FirstOrDefault(x => x.State != EventState.Completed);
            return nextEvent;
        }

        public IEnumerable<EventEntity> GetEventFlow(long flowId)
        {
            return _context.EventEntity.Where(x => x.FlowId == flowId).OrderBy(x => x.ProcessState);
        }

        private static DocumentType GetDocumentType(EventType eventType)
        {
            return eventType switch
            {
                EventType.HandleOsInfo => DocumentType.NetsOsInfo,
                EventType.HandleBs601 => DocumentType.Bs601,
                EventType.HandleBs605 => DocumentType.Bs605,
                EventType.HandleOs => DocumentType.NetsOs,
                EventType.GenerateIs => DocumentType.NetsIs,
                EventType.GenerateBs602 => DocumentType.Bs602,
                EventType.GenerateBs603 => DocumentType.Bs603,
                _ => throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null)
            };
        }
    }
}
