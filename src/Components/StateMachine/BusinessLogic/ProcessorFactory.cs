using Core.Models;
using StateMachine.Abstractions;
using StateMachine.BusinessLogic.Processors;

namespace StateMachine.BusinessLogic
{
    internal class ProcessorFactory
    {
        public static IProcessor GetProcessor(EventEntity entity)
        {
            switch (entity.ProcessState)
            {
                case ProcessState.Receive:
                    break;
                case ProcessState.Parse:
                    return new ParseFileProcessor();
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
