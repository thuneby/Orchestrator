using Core.OrchestratorModels;
using DataAccess.DataAccess;
using Document.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Document.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly InputFileRepository _inputFileRepository;
        private readonly OutputFileRepository _outputFileRepository;

        public ReceiptController(InputFileRepository inputFileRepository, OutputFileRepository outputFileRepository)
        {
            _inputFileRepository = inputFileRepository;
            _outputFileRepository = outputFileRepository;
        }

        [HttpPost("[Action]")]
        public async Task<Guid> GenerateReceipt(EventEntity entity, Guid documentId)
        {
            var inputFileName = await _inputFileRepository.GetInputFileName(documentId);
            if (string.IsNullOrEmpty(inputFileName))
                return Guid.Empty;
            var outputFile = ReceiptHandler.CreateOutPutFile(inputFileName, entity.DocumentType);
            outputFile.TenantÍd = entity.TenantÍd;
            outputFile.DocumentId = documentId;
            outputFile.FlowId = entity.FlowId;
            _outputFileRepository.Add(outputFile);
            return outputFile.Id;
        }
    }
}
