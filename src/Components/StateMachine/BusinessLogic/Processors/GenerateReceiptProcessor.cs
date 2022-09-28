using Core.OrchestratorModels;
using Document.Controllers;
using Microsoft.Extensions.Logging;
using StateMachine.Abstractions;

namespace StateMachine.BusinessLogic.Processors
{
    public class GenerateReceiptProcessor: IProcessor
    {
        private readonly ReceiptController _controller;
        private readonly ILogger<GenerateReceiptProcessor> _logger;

        public GenerateReceiptProcessor(ReceiptController controller, ILoggerFactory loggerFactory)
        {
            _controller = controller;
            _logger = loggerFactory.CreateLogger<GenerateReceiptProcessor>();
        } 
        
        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                var id = Guid.Parse(entity.Parameters);
                entity.Result = (await _controller.GenerateReceipt(entity, id)).ToString();
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
