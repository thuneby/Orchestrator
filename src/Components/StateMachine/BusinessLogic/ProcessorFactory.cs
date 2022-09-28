using Convert.Controllers;
using Core.OrchestratorModels;
using DataAccess.DataAccess;
using Document.Controllers;
using Ingestion.Controllers;
using Microsoft.Extensions.Logging;
using Parse.Controllers;
using Pay.Controllers;
using StateMachine.Abstractions;
using StateMachine.BusinessLogic.Processors;
using Validate.Controllers;

namespace StateMachine.BusinessLogic
{
    public class ProcessorFactory
    {
        private readonly ParseController _parseController;
        private readonly ReceiveFileController _receiveFileController;
        private readonly ConversionController _conversionController;
        private readonly ValidationController _validationController;
        private readonly PaymentController _paymentController;
        private readonly ReceiptController _receiptController;
        private readonly PaymentRepository _paymentRepository;
        private readonly ILoggerFactory _loggerFactory;
        public ProcessorFactory(ParseController parseController, ReceiveFileController receiveFileController, ConversionController conversionController, ValidationController validationController, PaymentController paymentController,
            ReceiptController receiptController, PaymentRepository paymentRepository, ILoggerFactory loggerFactory)
        {
            _parseController = parseController;
            _receiveFileController = receiveFileController;
            _conversionController = conversionController;
            _validationController = validationController;
            _paymentController = paymentController;
            _receiptController = receiptController;
            _paymentRepository = paymentRepository;
            _loggerFactory = loggerFactory;
        }
        public IProcessor? GetProcessor(EventEntity entity)
        {
            switch (entity.ProcessState)
            {
                case ProcessState.Receive:
                    return new ReceiveFileProcessor(_receiveFileController, _loggerFactory.CreateLogger<ReceiveFileProcessor>());
                case ProcessState.Parse:
                    return new ParseFileProcessor(_parseController, _loggerFactory);
                case ProcessState.Convert:
                    return new ConvertDocumentProcessor(_conversionController, _loggerFactory);
                case ProcessState.Validate:
                    return new ValidationProcessor(_paymentRepository, _validationController, _loggerFactory);
                case ProcessState.Pay:
                    return new PaymentProcessor(_paymentRepository, _paymentController, _loggerFactory);
                case ProcessState.GenerateReceipt:
                    return new GenerateReceiptProcessor(_receiptController, _loggerFactory);
                case ProcessState.Consolidate:
                    break;
                case ProcessState.TransferResult:
                    break;
                case ProcessState.AddCustomer:
                    break;
                case ProcessState.RemoveCustomer:
                    break;
                case ProcessState.WorkFlowCompleted:
                    return null;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return null;
        }
    }
}
