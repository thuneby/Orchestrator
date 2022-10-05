using Core.DomainModels;
using Core.Dtos;
using Core.OrchestratorModels;
using DataAccess.DataAccess;
using Microsoft.Extensions.Logging;
using ServiceInvocation.Extensions;
using StateMachine.Abstractions;

namespace StateMachine.BusinessLogic.Processors
{
    public class PaymentProcessor: IProcessor
    {
        private readonly PaymentRepository _paymentRepository;
        private readonly ILogger<PaymentProcessor> _logger;

        public PaymentProcessor(PaymentRepository paymentRepository, ILoggerFactory loggerFactory)
        {
            _paymentRepository = paymentRepository;
            _logger = loggerFactory.CreateLogger<PaymentProcessor>();
        }
        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                var id = Guid.Parse(entity.Parameters);
                var payments = _paymentRepository.GetFromDocumentId(id)
                    .Where(x => x.Valid && x.ReconcileStatus == ReconcileStatus.Open && x.DueDate.Date <= DateTime.Today).ToList();
                if (payments.Any())
                {
                    //var paymentResult = _paymentController.RequestPayments(payments);
                    var paymentResult = await ServiceInvoker.InvokeService<List<Payment>,IEnumerable<PaymentResult>>(HttpMethod.Post,"pay" , "payment/RequestPayments", payments);
                    foreach (var payment in payments.Where(payment => paymentResult.Any(x => x.PaymentId == payment.Id && x.Paid)))
                    {
                        payment.ReconcileStatus = ReconcileStatus.Paid;
                    }

                    await _paymentRepository.UpdateRange(payments);
                }

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
