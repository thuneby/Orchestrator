using Convert.BusinessLogic.Helpers;
using DataAccess.DataAccess;
using DocumentAccess.DocumentAccessLayer;

namespace Convert.BusinessLogic
{
    public class ConvertOsInfo: IAsyncConverter
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly PaymentRepository _paymentRepository;
        private readonly ILogger<ConvertOsInfo> _logger;

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
            {
                var error = "OsInfo document not found!, id: " + fileId;
                _logger.LogError(error);
                throw new ArgumentException(error);
            }
            var infoSections = startRecord.OsInfoSectionStartCollection;
            if (!infoSections.Any())
            {
                var error = "OsInfo document does not contain any sections!, id: " + fileId;
                _logger.LogError(error, startRecord);
                throw new ArgumentException(error);
            }
            var paymentList = infoSections.Select(infoSectionStart => ConvertOsInfoHelper.GetPayment(fileId, infoSectionStart)).ToList();
            await _paymentRepository.AddRange(paymentList);
            return fileId;
        }

    }
}
