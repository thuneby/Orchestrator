namespace Orchestrator.Core.Models
{
    public abstract class Saga: TenantModelBase, ISaga
    {
        public ProcessState InitialState { get; set; }
        public ProcessState FinalState { get; set; } = ProcessState.WorkFlowCompleted;
        public ICollection<ProcessState> ProcessStates { get; set; }
        public IDictionary<ProcessState, ProcessState> StateMap { get; set; }
    }
}
