namespace Orchestrator.Core.Models
{
    public enum EventState
    {
        New = 0,
        Processing = 1,
        Completed = 2,
        Error = -1
    }
}
