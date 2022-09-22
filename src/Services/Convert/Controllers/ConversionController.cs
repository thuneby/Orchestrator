using Core.Models;
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
        private readonly ILogger<ConversionController> _logger;

        public ConversionController(PaymentRepository paymentRepository, IDocumentRepository documentRepository, ILogger<ConversionController> logger)
        {
            _paymentRepository = paymentRepository;
            _documentRepository = documentRepository;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public async Task<Guid> ConvertDocument(Guid documentId, DocumentType documentType, long tenantId)
        {
            return documentId;
        }
    }
}
