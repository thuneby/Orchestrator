using Core.Models;
using DataAccess.DataAccess;
using Ingestion.Controllers;
using Microsoft.Extensions.Logging;
using Parse.Controllers;
using StateMachine.Abstractions;
using StateMachine.BusinessLogic.Processors;

namespace StateMachine.BusinessLogic
{
    public class ProcessorFactory
    {
        private readonly ParseController _parseController;
        private readonly ReceiveFileController _receiveFileController;
        private readonly EventRepository _eventRepository;
        private readonly ILoggerFactory _loggerFactory;
        public ProcessorFactory(ParseController parseController, ReceiveFileController receiveFileController, EventRepository eventRepository, ILoggerFactory loggerFactory)
        {
            _parseController = parseController;
            _receiveFileController = receiveFileController;
            _eventRepository = eventRepository;
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
                case ProcessState.Pay:
                    break;
                case ProcessState.Validate:
                    break;
                case ProcessState.TransferResult:
                    break;
                case ProcessState.AddCustomer:
                    break;
                case ProcessState.RemoveCustomer:
                    break;
                case ProcessState.WorkFlowCompleted:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return null;
        }
    }
}
