using Core.Models;
using DataAccess.Common;
using DataAccess.DataAccess;
using Microsoft.Extensions.Logging;

namespace StateMachine.BusinessLogic
{
    public class WorkFlowProcessor
    {
        private readonly EventRepository _eventRepository;
        private readonly ILogger _logger;

        public WorkFlowProcessor(EventRepository eventRepository, ILogger<WorkFlowProcessor> logger)
        {
            _eventRepository = eventRepository;
            _logger = logger;
        }

        
        public async Task<EventEntity> ProcessEvent(EventEntity eventEntity, bool returnNewEvent = true)
        {
            try
            {
                if (eventEntity.ProcessState == ProcessState.WorkFlowCompleted)
                    return eventEntity;
                eventEntity = await DoProcessing(eventEntity);
                if (eventEntity.State == EventState.Completed)
                {
                    var newEvent = GetNextEvent(eventEntity);
                    // Update current event
                    _eventRepository.Update(eventEntity);
                    // Add new event
                    _eventRepository.AddOrUpdateEventEntity(newEvent);
                    return returnNewEvent ? newEvent : eventEntity;
                }

                _eventRepository.Update(eventEntity);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                eventEntity.ErrorMessage = e.Message;
                eventEntity.State = EventState.Error;
            }
            return eventEntity;
        }

        public async Task<EventEntity> DoProcessing(EventEntity entity)
        {
            if (entity.State == EventState.Completed)
                return entity;
            _eventRepository.Update(ProcessHelper.StartEvent(entity)); // make sure nobody else takes it
            var processor = ProcessorFactory.GetProcessor(entity);
            if (processor == null)
            {
                entity.ErrorMessage = "Processor not found for event!";
                entity.State = EventState.Error;
                return entity;
            }
            var result = await processor.ProcessEvent(entity);
            return result;
        }

        private EventEntity GetNextEvent(EventEntity originalEvent)
        {
            if (originalEvent.ProcessState == ProcessState.WorkFlowCompleted)
                return originalEvent;
            var entity = new EventEntity()
            {
                State = EventState.New,
                FlowId = originalEvent.FlowId,
                TenantÍd = originalEvent.TenantÍd,
                ProcessState = StateMap.GetNextStep(originalEvent),
                Parameters = originalEvent.Result
            };
            return entity;
        }
    }
}
