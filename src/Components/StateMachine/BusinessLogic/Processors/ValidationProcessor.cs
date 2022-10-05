using Core.DomainModels;
using Core.Dtos;
using Core.OrchestratorModels;
using DataAccess.DataAccess;
using Microsoft.Extensions.Logging;
using ServiceInvocation.Extensions;
using StateMachine.Abstractions;

namespace StateMachine.BusinessLogic.Processors
{
    public class ValidationProcessor: IProcessor
    {
        private readonly PaymentRepository _paymentRepository;
        private readonly ILogger<ValidationProcessor> _logger;

        public ValidationProcessor(PaymentRepository paymentRepository, ILoggerFactory loggerFactory)
        {
            _paymentRepository = paymentRepository;
            _logger = loggerFactory.CreateLogger<ValidationProcessor>();
        }

        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                var id = Guid.Parse(entity.Parameters); 
                var payments = _paymentRepository.GetFromDocumentId(id).ToList();
                //var results = (await _validationController.ValidatePaymentList(payments)).ToList();
                var results = (await ServiceInvoker.InvokeService<List<Payment>, IEnumerable<ValidationResult>>(HttpMethod.Post, "", "", payments)).ToList();
                foreach (var validationResult in results)
                {
                    var payment = payments.FirstOrDefault(x => x.Id == validationResult.PaymentId);
                    if (payment == null)
                        continue;
                    payment.Valid = validationResult.Valid;
                }

                await _paymentRepository.UpdateRange(payments);
                if (results.All(x => x.Valid))
                {
                    entity.Result = entity.Parameters;
                }
                else
                {
                    entity.Result = entity.Parameters;
                    var errorMessages = results.SelectMany(x => x.ValidationErrors);
                    entity.ErrorMessage = errorMessages.ToString();
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
