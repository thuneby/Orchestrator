using Core.Models;

namespace StateMachine.BusinessLogic
{
    internal static class StateMap
    {
        public static ProcessState GetNextStep(EventEntity entity)
        {
            var currentStep = entity.ProcessState;
            return currentStep switch
            {
                ProcessState.Receive => ProcessState.Parse,
                ProcessState.Parse => ProcessState.Validate,
                ProcessState.Validate => ProcessState.Pay,
                ProcessState.Pay => ProcessState.Consolidate,
                ProcessState.Consolidate => ProcessState.TransferResult,
                ProcessState.TransferResult => ProcessState.WorkFlowCompleted,
                ProcessState.AddCustomer => ProcessState.WorkFlowCompleted,
                ProcessState.RemoveCustomer => ProcessState.WorkFlowCompleted,
                ProcessState.WorkFlowCompleted => ProcessState.WorkFlowCompleted,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
