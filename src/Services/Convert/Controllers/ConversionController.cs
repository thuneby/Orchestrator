using Convert.BusinessLogic;
using Core.OrchestratorModels;
using DataAccess.DataAccess;
using DocumentAccess.DocumentAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace Convert.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversionController: ControllerBase
    {
        private readonly PaymentRepository _paymentRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly ILoggerFactory _loggerFactory;

        public ConversionController(PaymentRepository paymentRepository, IDocumentRepository documentRepository, ILoggerFactory loggerFactory)
        {
            _paymentRepository = paymentRepository;
            _documentRepository = documentRepository;
            _loggerFactory = loggerFactory;
        }

        [HttpPost("[action]")]
        public async Task<Guid> ConvertDocument(EventEntity entity)
        {
            var documentId = Guid.Parse(entity.Parameters);
            var converter = ConverterFactory.GetConverter(entity.DocumentType, _documentRepository, _paymentRepository, _loggerFactory);
            var result = await converter.Convert(documentId, entity.TenantÍd);
            return result;
        }
    }
}
