namespace Orchestrator.Core.Models
{
    public enum ProcessState
    {
        Receive,
        Parse,
        Process,
        Validate,
        PutResult,
        AddCustomer,
        RemoveCustomer,
        WorkFlowCompleted
    }
}
