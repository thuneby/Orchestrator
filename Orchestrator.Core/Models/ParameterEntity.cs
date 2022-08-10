namespace Orchestrator.Core.Models
{
    public class ParameterEntity: GuidModelBase
    {
        public EventType EventType { get; set; }
        public ParameterType ParameterType { get; set; }
        public string Value { get; set; }
    }
}
