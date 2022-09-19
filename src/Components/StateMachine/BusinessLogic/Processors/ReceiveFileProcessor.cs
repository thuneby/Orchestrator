using Core.Models;
using Ingestion.Controllers;
using Microsoft.Extensions.Logging;
using StateMachine.Abstractions;

namespace StateMachine.BusinessLogic.Processors
{
    public class ReceiveFileProcessor: IProcessor
    {
        private readonly ReceiveFileController _controller;
        private readonly ILogger<ReceiveFileProcessor> _logger;

        public ReceiveFileProcessor(ReceiveFileController controller, ILogger<ReceiveFileProcessor> logger)
        {
            _controller = controller;
            _logger = logger;
        }

        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                entity = await _controller.ExecuteReceiveEvent(entity);
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
