using BlobAccess.DataAccessLayer.Helpers;
using Core.Models;
using DocumentAccess.DocumentAccessLayer;
using DocumentAccess.Models;

namespace Parse.BusinessLogic
{
    public static class ParserFactory
    {
        public static IAsyncParser GetParser(DocumentType documentType, IStorageHelper storageHelper, IDocumentRepository documentRepository, ILoggerFactory loggerFactory)
        {
            return documentType switch
            {
                DocumentType.NetsOsInfo => new ParseOsInfo(storageHelper, documentRepository, loggerFactory),
                
                _ => null
            };
        }
    }
}
