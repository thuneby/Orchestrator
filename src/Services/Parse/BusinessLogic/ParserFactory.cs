using System.Runtime.InteropServices.ComTypes;
using BlobAccess.DataAccessLayer.Helpers;
using Core.CoreModels;
using DocumentAccess.DocumentAccessLayer;
using DocumentAccess.Models;

namespace Parse.BusinessLogic
{
    public static class ParserFactory
    {
        public static IAsyncParser? GetParser(DocumentType documentType, IStorageHelper storageHelper, IDocumentRepository documentRepository, ILoggerFactory loggerFactory)
        {
            return documentType switch
            {
                DocumentType.NetsOsInfo => new ParseOsInfo(storageHelper, documentRepository, loggerFactory),
                DocumentType.Bs601 => new ParseBs601(storageHelper, documentRepository, loggerFactory),
                _ => null
            };
        }
    }
}
