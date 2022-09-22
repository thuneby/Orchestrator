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
                case EventType.LoadOsInfo:
                {
                    return currentStep switch
                    {
                        ProcessState.Receive => ProcessState.Parse,
                        ProcessState.Parse => ProcessState.GeneratePayments,
                        ProcessState.GeneratePayments => ProcessState.Validate,
                        ProcessState.Validate => ProcessState.Pay,
                        ProcessState.Pay => ProcessState.Consolidate,
                        ProcessState.Consolidate => ProcessState.TransferResult,
                        ProcessState.TransferResult => ProcessState.WorkFlowCompleted,
                        ProcessState.WorkFlowCompleted => ProcessState.WorkFlowCompleted,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                }
                case EventType.AddCustomer:
                {
                    return currentStep switch
                    {
                        ProcessState.AddCustomer => ProcessState.WorkFlowCompleted,
                        ProcessState.WorkFlowCompleted => ProcessState.WorkFlowCompleted,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                }
                case EventType.RemoveCustomer:
                {
                    return currentStep switch
                    {
                        ProcessState.RemoveCustomer => ProcessState.WorkFlowCompleted,
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
