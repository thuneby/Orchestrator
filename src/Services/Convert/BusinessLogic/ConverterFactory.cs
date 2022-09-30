using Core.CoreModels;
using DataAccess.DataAccess;
using DocumentAccess.DocumentAccessLayer;


namespace Convert.BusinessLogic
{
    public class ConverterFactory
    {
        public static IAsyncConverter GetConverter(DocumentType documentType, IDocumentRepository documentRepository, PaymentRepository paymentRepository, ILoggerFactory loggerFactory)
        {
            return documentType switch
            {
                DocumentType.NetsOsInfo => new ConvertOsInfo(documentRepository, paymentRepository, loggerFactory),

                _ => null
            };
        }
    }
}
