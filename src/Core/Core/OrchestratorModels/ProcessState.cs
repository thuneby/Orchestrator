namespace Core.OrchestratorModels
{
    public enum ProcessState
    {
        Receive = 10,
        Parse = 20,
        GeneratePayments = 30,
        Validate = 40,
        Pay = 50,
        Consolidate = 60,
        GenerateReceipt = 70,
        TransferResult = 90,
        AddCustomer = 110,
        RemoveCustomer = 120,
        WorkFlowCompleted = 999
    }
}
