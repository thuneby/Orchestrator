namespace Core.Models
{
    public enum ProcessState
    {
        Receive,
        Parse,
        GeneratePayments,
        Validate,
        Pay,
        Consolidate,
        TransferResult,
        AddCustomer,
        RemoveCustomer,
        WorkFlowCompleted
    }
}
