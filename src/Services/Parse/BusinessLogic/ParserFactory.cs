using BlobAccess.DataAccessLayer.Helpers;
using Core.Models;
using DocumentAccess.Models;

namespace Parse.BusinessLogic
{
    public static class ParserFactory
    {
        public static IAsyncParser GetParser(DocumentType documentType, IStorageHelper storageHelper, DocumentContext context, ILoggerFactory loggerFactory)
        {
            return documentType switch
            {
                DocumentType.NetsOsInfo => new ParseOsInfo(storageHelper, context, loggerFactory),
                
                _ => null
            };
        }
    }
}
