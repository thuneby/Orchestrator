using System.Text;
using Core.CoreModels;

namespace Parse.BusinessLogic.Helpers
{
    public static class EncodingHelper
    {
        public static Encoding GetEncoding(DocumentType documentType)
        {
            return documentType switch
            {
                DocumentType.NetsOs => Encoding.GetEncoding(28591),
                DocumentType.NetsOsInfo => Encoding.GetEncoding(28591),
                DocumentType.NetsIs => Encoding.GetEncoding(28591),
                DocumentType.Excel => Encoding.Default,
                DocumentType.Unknown => Encoding.Default,
                _ => Encoding.Default
            };
        }
    }
}
