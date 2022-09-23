using Core.OrchestratorModels;
using Microsoft.Extensions.Logging;
using StateMachine.Abstractions;

namespace StateMachine.BusinessLogic.Processors
{
    public class PaymentProcessor: IProcessor
    {
        private readonly ILogger<PaymentProcessor> _logger;

        public PaymentProcessor(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PaymentProcessor>();
        }
        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                var id = Guid.Parse(entity.Parameters);

                // Do Stuff

                entity.Result = entity.Parameters;
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
