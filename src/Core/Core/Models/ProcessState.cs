namespace Core.Models
{
    public enum ProcessState
    {
        Receive,
        Parse,
        Validate,
        Pay,
        Consolidate,
        TransferResult,
        AddCustomer,
        RemoveCustomer,
        WorkFlowCompleted
    }
}
