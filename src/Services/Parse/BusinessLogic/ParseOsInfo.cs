using BlobAccess.DataAccessLayer.Helpers;
using DocumentAccess.Models;

namespace Parse.BusinessLogic
{
    public class ParseOsInfo : IAsyncParser
    {
        private IStorageHelper storageHelper;
        private DocumentContext context;
        private ILoggerFactory loggerFactory;

        public ParseOsInfo(IStorageHelper storageHelper, DocumentContext context, ILoggerFactory loggerFactory)
        {
            this.storageHelper = storageHelper;
            this.context = context;
            this.loggerFactory = loggerFactory;
        }

        public async Task<Guid> Parse(Guid fileId)
        {
            throw new NotImplementedException();
        }
    }
}
