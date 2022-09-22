using Core.DomainModels;
using DataAccess.DataAccess;
using DocumentAccess.DocumentAccessLayer;
using FileHelpers.Events;

namespace Convert.BusinessLogic
{
    public class ConvertOsInfo: IAsyncConverter
    {
        private IDocumentRepository _documentRepository;
        private PaymentRepository _paymentRepository;
        private ILogger<ConvertOsInfo> _logger;

        public ConvertOsInfo(IDocumentRepository documentRepository, PaymentRepository paymentRepository, ILoggerFactory loggerFactory)
        {
            _documentRepository = documentRepository;
            _paymentRepository = paymentRepository;
            _logger = loggerFactory.CreateLogger<ConvertOsInfo>();
        }

        public async Task<Guid> Convert(Guid fileId, long tenantId)
        {
            var startRecord = _documentRepository.GetOsInfo(fileId);
            if (startRecord == null)
                return Guid.Empty;
            var paymentList = new List<Payment>();
            await _paymentRepository.AddRange(paymentList);
            return fileId;
        }
    }
}
