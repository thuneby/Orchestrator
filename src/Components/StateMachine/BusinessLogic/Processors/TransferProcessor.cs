using Core.OrchestratorModels;
using Microsoft.Extensions.Logging;
using StateMachine.Abstractions;
using Transfer.Controllers;

namespace StateMachine.BusinessLogic.Processors
{
    public class TransferProcessor: IProcessor
    {
        private readonly TransferController _controller;
        private readonly ILogger<TransferProcessor> _logger;

        public TransferProcessor(TransferController controller, ILoggerFactory loggerFactory)
        {
            _controller = controller;
            _logger = loggerFactory.CreateLogger<TransferProcessor>();
        }

        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                entity.Result = await _controller.TransferToRecipient(entity);
                entity.UpdateProcessResult();
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
