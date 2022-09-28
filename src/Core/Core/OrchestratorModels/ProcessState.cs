namespace Core.OrchestratorModels
{
    public enum ProcessState
    {
        Receive = 10,
        Parse = 20,
        Convert = 30,
        Validate = 40,
        Consolidate = 50,
        Pay = 55,
        GenerateReceipt = 60,
        TransferResult = 90,
        AddCustomer = 110,
        RemoveCustomer = 120,
        WorkFlowCompleted = 999
    }
}
