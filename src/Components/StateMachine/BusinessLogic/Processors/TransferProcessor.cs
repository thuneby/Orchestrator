using Core.OrchestratorModels;
using Microsoft.Extensions.Logging;
using ServiceInvocation.Extensions;
using StateMachine.Abstractions;

namespace StateMachine.BusinessLogic.Processors
{
    public class TransferProcessor: IProcessor
    {
        private readonly ILogger<TransferProcessor> _logger;

        public TransferProcessor(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TransferProcessor>();
        }

        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                //entity.Result = await _controller.TransferToRecipient(entity);
                entity.Result = await ServiceInvoker.InvokeService<EventEntity, string>(HttpMethod.Post, "transfer", "transfer/TransferToRecipient", entity);
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
