using Core.OrchestratorModels;
using Microsoft.Extensions.Logging;
using ServiceInvocation.Extensions;
using StateMachine.Abstractions;

namespace StateMachine.BusinessLogic.Processors
{
    public class ReceiveFileProcessor: IProcessor
    {
        private readonly ILogger<ReceiveFileProcessor> _logger;

        public ReceiveFileProcessor(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ReceiveFileProcessor>();
        }

        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                //entity = await _controller.ExecuteReceiveEvent(entity);
                entity = await EventServiceInvoker.InvokeService(HttpMethod.Post, "ingestion", "receivefile/ExecuteReceiveEvent", entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                entity.ErrorMessage = e.Message;
                entity.UpdateProcessResult(EventState.Error);
            }

            return entity;
        }

    }
}
