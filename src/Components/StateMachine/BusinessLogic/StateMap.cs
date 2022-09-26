using Core.OrchestratorModels;

namespace StateMachine.BusinessLogic
{
    internal static class StateMap
    {
        public static ProcessState GetNextStep(EventEntity entity)
        {
            var currentStep = entity.ProcessState;
            switch (entity.EventType)
            {
                case EventType.HandleOs:
                case EventType.HandleBs601:
                case EventType.HandleOsInfo:
                {
                    return currentStep switch
                    {
                        ProcessState.Receive => ProcessState.Parse,
                        ProcessState.Parse => ProcessState.GeneratePayments,
                        ProcessState.GeneratePayments => ProcessState.Validate,
                        ProcessState.Validate => ProcessState.Pay,
                        ProcessState.Pay => ProcessState.GenerateReceipt,
                        ProcessState.GenerateReceipt => ProcessState.TransferResult,
                        ProcessState.TransferResult => ProcessState.WorkFlowCompleted,
                        ProcessState.WorkFlowCompleted => ProcessState.WorkFlowCompleted,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                }
                case EventType.GenerateIs:
                case EventType.GenerateBs602:
                {
                    return currentStep switch
                    {
                        ProcessState.Consolidate => ProcessState.Pay,
                        ProcessState.Pay => ProcessState.TransferResult,
                        ProcessState.TransferResult => ProcessState.WorkFlowCompleted,
                        ProcessState.WorkFlowCompleted => ProcessState.WorkFlowCompleted,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                }
                case EventType.HandleBs605:
                {
                    return currentStep switch
                    {
                        ProcessState.AddCustomer => ProcessState.WorkFlowCompleted,
                        ProcessState.WorkFlowCompleted => ProcessState.WorkFlowCompleted,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}
