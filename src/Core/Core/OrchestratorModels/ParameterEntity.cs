using Core.Models;

namespace Core.OrchestratorModels
{
    public class ParameterEntity : GuidModelBase
    {
        public EventType EventType { get; set; }
        public ParameterType ParameterType { get; set; }
        public string Value { get; set; }
    }
}
