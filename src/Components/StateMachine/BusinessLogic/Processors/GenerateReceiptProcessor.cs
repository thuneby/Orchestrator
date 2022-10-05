using Core.OrchestratorModels;
using Microsoft.Extensions.Logging;
using ServiceInvocation.Extensions;
using StateMachine.Abstractions;

namespace StateMachine.BusinessLogic.Processors
{
    public class GenerateReceiptProcessor: IProcessor
    {
        private readonly ILogger<GenerateReceiptProcessor> _logger;

        public GenerateReceiptProcessor(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GenerateReceiptProcessor>();
        } 
        
        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                //entity.Result = (await _controller.GenerateReceipt(entity)).ToString();
                entity.Result = (await ServiceInvoker.InvokeService<EventEntity, Guid>(HttpMethod.Post, "document", "receipt/GenerateReceipt", entity)).ToString();
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
