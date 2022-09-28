using Core.CoreModels;

namespace Utilities.Encoding
{
    public static class EncodingHelper
    {
        public static System.Text.Encoding GetEncoding(DocumentType documentType)
        {
            return documentType switch
            {
                DocumentType.NetsOs => System.Text.Encoding.GetEncoding(28591),
                DocumentType.NetsOsInfo => System.Text.Encoding.GetEncoding(28591),
                DocumentType.NetsIs => System.Text.Encoding.GetEncoding(28591),
                DocumentType.Excel => System.Text.Encoding.Default,
                DocumentType.Unknown => System.Text.Encoding.Default,
                _ => System.Text.Encoding.Default
            };
        }
    }
}
