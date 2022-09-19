using DocumentAccess.Models;
using ExternalModels.MasterCard.OsInfoModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DocumentAccess.DocumentAccessLayer
{
    public class DocumentRepository: IDocumentRepository
    {
        private readonly DocumentContext _documentContext;
        private readonly ILogger<DocumentRepository> _logger;

        public DocumentRepository(DocumentContext context, ILogger<DocumentRepository> logger)
        {
            _documentContext = context;
            _logger = logger;
        }
        
        public async Task SaveModel(FlatOsInfoModel model)
        {
            try
            {
                _documentContext.OsInfoStart.Add(model.OsInfoStart);
                _documentContext.OsInfoEnd.Add(model.OsInfoEnd);
                _documentContext.OsSectionStart.AddRange(model.OsInfoSectionStartCollection);
                _documentContext.OsSectionEnd.AddRange(model.OsInfoSectionEndCollection);
                _documentContext.OsRecord00.AddRange(model.OsInfoRecord00Collection);
                _documentContext.OsRecord01.AddRange(model.OsInfoRecord01Collection);
                _documentContext.OsRecord02.AddRange(model.OsInfoRecord02Collection);
                _documentContext.OsRecord03.AddRange(model.OsInfoRecord03Collection);
                _documentContext.OsRecord04.AddRange(model.OsInfoRecord04Collection);
                _documentContext.OsRecord05.AddRange(model.OsInfoRecord05Collection);
                _documentContext.OsRecord10.AddRange(model.OsInfoRecord10Collection);
                await _documentContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        public bool OsInfoExists(Guid id) 
        {
            var startRecord = _documentContext.OsInfoStart.FirstOrDefaultAsync(x => x.Id == id);
            return startRecord != null;
        }

        public OsInfoStart? GetOsInfo(Guid id)
        {
            var startRecord = _documentContext.OsInfoStart
                .Include(x => x.OsInfoEndCollection)
                .Include(x => x.OsInfoSectionStartCollection)
                .ThenInclude(x => x.OsSectionEnd)
                .FirstOrDefault(x => x.Id == id);

            if (startRecord == null)
                return startRecord;

            var osInfoRecords = GetOsRecord00List(_documentContext, id).ToList();

            foreach (var osInfoSectionStart in startRecord.OsInfoSectionStartCollection)
            {
                osInfoSectionStart.OsRecord00Collection =
                    osInfoRecords.Where(x => x.OsSectionStart.Id == osInfoSectionStart.Id).ToList();
            }

            return startRecord;
        }

        private static IEnumerable<OsInfoRecord00> GetOsRecord00List(DocumentContext context, Guid startRecordId)
        {
            var record00List = context.OsRecord00.Where(x => x.OsSectionStart.OsStart.Id == startRecordId)
                .Include(x => x.OsSectionStart)
                .Include(x => x.OsRecord01Collection)
                .Include(x => x.OsRecord02Collection)
                .Include(x => x.OsRecord03Collection)
                .Include(x => x.OsRecord04Collection)
                .Include(x => x.OsRecord05Collection)
                .Include(x => x.OsRecord10Collection);
            return record00List.ToList();
        }
    }
}
