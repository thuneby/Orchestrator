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
using Transfer.Controllers;
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
        private readonly TransferController _transferController;
        private readonly PaymentRepository _paymentRepository;
        private readonly ILoggerFactory _loggerFactory;
        public ProcessorFactory(ParseController parseController, ReceiveFileController receiveFileController, ConversionController conversionController, ValidationController validationController, PaymentController paymentController,
            ReceiptController receiptController, TransferController transferController, PaymentRepository paymentRepository, ILoggerFactory loggerFactory)
        {
            _parseController = parseController;
            _receiveFileController = receiveFileController;
            _conversionController = conversionController;
            _validationController = validationController;
            _paymentController = paymentController;
            _receiptController = receiptController;
            _transferController = transferController;
            _paymentRepository = paymentRepository;
            _loggerFactory = loggerFactory;
        }
        public IProcessor? GetProcessor(EventEntity entity)
        {
            return entity.ProcessState switch
            {
                ProcessState.Receive => new ReceiveFileProcessor(_receiveFileController, _loggerFactory.CreateLogger<ReceiveFileProcessor>()),
                ProcessState.Parse => new ParseFileProcessor(_parseController, _loggerFactory),
                ProcessState.Convert => new ConvertDocumentProcessor(_conversionController, _loggerFactory),
                ProcessState.Validate => new ValidationProcessor(_paymentRepository, _validationController, _loggerFactory),
                ProcessState.Pay => new PaymentProcessor(_paymentRepository, _paymentController, _loggerFactory),
                ProcessState.GenerateReceipt => new GenerateReceiptProcessor(_receiptController, _loggerFactory),
                ProcessState.TransferResult => new TransferProcessor(_transferController, _loggerFactory),
                ProcessState.WorkFlowCompleted => null,
                _ => null
            };
        }
    }
}
