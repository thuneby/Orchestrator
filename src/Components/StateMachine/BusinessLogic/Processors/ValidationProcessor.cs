using Core.OrchestratorModels;
using DataAccess.DataAccess;
using Microsoft.Extensions.Logging;
using StateMachine.Abstractions;
using Validate.Controllers;

namespace StateMachine.BusinessLogic.Processors
{
    public class ValidationProcessor: IProcessor
    {
        private readonly PaymentRepository _paymentRepository;
        private readonly ValidationController _validationController;
        private readonly ILogger<ValidationProcessor> _logger;

        public ValidationProcessor(PaymentRepository paymentRepository, ValidationController validationController, ILoggerFactory loggerFactory)
        {
            _paymentRepository = paymentRepository;
            _validationController = validationController;
            _logger = loggerFactory.CreateLogger<ValidationProcessor>();
        }

        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                var id = Guid.Parse(entity.Parameters);
                var payment = _paymentRepository.Get(id);
                var result = await _validationController.ValidatePayment(payment);
                if (result.Valid)
                {
                    entity.Result = "Validated";
                    payment.Valid = true;
                    _paymentRepository.Update(payment);
                }
                else
                {
                    entity.ErrorMessage = result.ValidationErrors.ToString();
                }
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
