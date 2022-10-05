using Core.OrchestratorModels;
using DataAccess.DataAccess;
using Microsoft.Extensions.Logging;
using StateMachine.Abstractions;
using StateMachine.BusinessLogic.Processors;

namespace StateMachine.BusinessLogic
{
    public class ProcessorFactory
    {
        private readonly PaymentRepository _paymentRepository;
        private readonly ILoggerFactory _loggerFactory;
        public ProcessorFactory(PaymentRepository paymentRepository, ILoggerFactory loggerFactory)
        {
            _paymentRepository = paymentRepository;
            _loggerFactory = loggerFactory;
        }
        public IProcessor? GetProcessor(EventEntity entity)
        {
            return entity.ProcessState switch
            {
                ProcessState.Receive => new ReceiveFileProcessor(_loggerFactory),
                ProcessState.Parse => new ParseFileProcessor(_loggerFactory),
                ProcessState.Convert => new ConvertDocumentProcessor(_loggerFactory),
                ProcessState.Validate => new ValidationProcessor(_paymentRepository, _loggerFactory),
                ProcessState.Pay => new PaymentProcessor(_paymentRepository, _loggerFactory),
                ProcessState.GenerateReceipt => new GenerateReceiptProcessor(_loggerFactory),
                ProcessState.TransferResult => new TransferProcessor(_loggerFactory),
                ProcessState.WorkFlowCompleted => null,
                _ => null
            };
        }
    }
}
