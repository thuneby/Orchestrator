namespace Orchestrator.Core.Models
{
    public interface ISaga
    {
        ProcessState InitialState { get; set; }
        ProcessState FinalState { get; set; }
        ICollection<ProcessState> ProcessStates { get; set; }
        IDictionary<ProcessState,ProcessState> StateMap { get; set; }
    }
}
