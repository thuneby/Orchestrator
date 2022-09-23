using Core.CoreModels;

namespace Core.OrchestratorModels
{
    public abstract class Saga : TenantModelBase, ISaga
    {
        public Saga()
        {
            ProcessStates = new List<ProcessState>();
        }
        public ProcessState InitialState { get; set; }
        public ProcessState FinalState { get; set; } = ProcessState.WorkFlowCompleted;
        public ICollection<ProcessState> ProcessStates { get; set; }
        public IDictionary<ProcessState, ProcessState> StateMap { get; set; }
    }
}
