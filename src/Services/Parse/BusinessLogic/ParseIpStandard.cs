using BlobAccess.DataAccessLayer.Helpers;
using Core.CoreModels;
using DocumentAccess.DocumentAccessLayer;
using ExternalModels.IndustriensPension;
using Parse.BusinessLogic.Helpers;
using Parse.BusinessLogic.Mappers.IpFormat;

namespace Parse.BusinessLogic
{
    public class ParseIpStandard : IAsyncParser
    {
        private readonly IStorageHelper _storageHelper;
        private readonly IDocumentRepository _documentRepository;
        private readonly ILogger<ParseIpStandard> _logger;

        public ParseIpStandard(IStorageHelper storageHelper, IDocumentRepository documentRepository, ILoggerFactory loggerFactory)
        {
            _storageHelper = storageHelper;
            _documentRepository = documentRepository;
            _logger = loggerFactory.CreateLogger<ParseIpStandard>();
        }
        
        public async Task<Guid> Parse(Guid fileId, long tenantId)
        {
            var helper = new ParseIpStandardHelper();
            var mapper = new IpStandardMapper(tenantId);
            var (textRecords,errors) = await helper.GetRecordsFromPayload(fileId, _storageHelper, DocumentType.IpStandard);
            if (errors.Any())
            {
                var exception = new Exception(errors.FirstOrDefault());
                throw exception;
            }
            if (!textRecords.Any())
            {
                var error = "Error - format is not IpStandard";
                _logger.LogError(error);
                var exception = new Exception(error);
                throw exception;
            }

            var ipStartRecord = CreateIpStartRecord(IpFormat.IpStandard, tenantId);
            var ipRecords = new HashSet<IpRecord>();
            foreach (var textRecord in textRecords)
            {
                var record = mapper.Map(textRecord);
                record.IpStartRecord = ipStartRecord;
                ipRecords.Add(record);
            }

            return await SaveModel(ipStartRecord, ipRecords);
        }

        private async Task<Guid> SaveModel(IpStartRecord ipStartRecord, HashSet<IpRecord> ipRecords)
        {
            var model = new FlatIpModel()
            {
                IpStartRecord = ipStartRecord,
                IpRecords = ipRecords
            };
            await _documentRepository.SaveModel(model);
            return ipStartRecord.Id;
        }

        private static IpStartRecord CreateIpStartRecord(IpFormat format, long tenantId)
        {
            var ipStartRecord = new IpStartRecord
            {
                IpFormat = format,
                TenantÍd = tenantId
            };
            return ipStartRecord;
        }
    }
}
