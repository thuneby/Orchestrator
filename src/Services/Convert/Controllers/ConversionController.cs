using Convert.BusinessLogic;
using Core.CoreModels;
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
        public async Task<Guid> ConvertDocument(Guid documentId, DocumentType documentType, long tenantId)
        {
            var converter = ConverterFactory.GetConverter(documentType, _documentRepository, _paymentRepository, _loggerFactory);
            var result = await converter.Convert(documentId, tenantId);
            return result;
        }
    }
}
