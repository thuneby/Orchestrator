using Core.Models;
using Core.OrchestratorModels;

namespace Core.QueueModels
{
    public class QueueMessage : GuidModelBase
    {
        public QueueMessage(Guid id, DocumentType documentType, ProcessState processState, string fileName, string payload = "")
        {
            Id = id;
            DocumentType = documentType;
            FileName = fileName;
            ProcessState = processState;
            Payload = payload;
        }

        public DocumentType DocumentType { get; set; }
        public ProcessState ProcessState { get; set; }
        public string FileName { get; set; }
        public string Payload { get; set; }
    }
}
