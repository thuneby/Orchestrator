namespace Core.Models
{
    public enum ProcessState
    {
        Receive,
        Parse,
        Validate,
        GeneratePayments,
        Pay,
        Consolidate,
        TransferResult,
        AddCustomer,
        RemoveCustomer,
        WorkFlowCompleted
    }
}
