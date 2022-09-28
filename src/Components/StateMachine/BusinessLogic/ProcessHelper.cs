using Core.CoreModels;
using Core.OrchestratorModels;

namespace StateMachine.BusinessLogic
{
    public static class ProcessHelper
    {
        public static DocumentType GetDocumentType(EventType eventType)
        {
            return eventType switch
            {
                EventType.HandleOsInfo => DocumentType.NetsOsInfo,
                EventType.HandleBs601 => DocumentType.Bs601,
                EventType.HandleBs605 => DocumentType.Bs605,
                EventType.HandleOs => DocumentType.NetsOs,
                EventType.GenerateIs => DocumentType.NetsIs,
                EventType.GenerateBs602 => DocumentType.Bs602,
                EventType.GenerateBs603 => DocumentType.Bs603,
                _ => throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null)
            };
        }
    }
}
