using Core.CoreModels;
using Utilities.Encoding;

namespace Document.BusinessLogic
{
    public class ReceiptHandler
    {

        public static OutputFile CreateOutPutFile(string inputFileName, DocumentType documentType)
        {
            var contentString = GetContent(inputFileName, documentType);
            return GenerateOutPutFile(documentType, contentString, inputFileName);
        }

        private static OutputFile GenerateOutPutFile(DocumentType documentType, string contentString, string inputFileName)
        {
            var fileName = GetOutputFileName(inputFileName);
            var content = EncodingHelper.GetEncoding(documentType).GetBytes(contentString);
            var outputFile = new OutputFile
            {
                FileName = fileName,
                Content = content,
                Size = content.Length,
                DocumentType = GetDocumentType(documentType)
            };
            return outputFile;
        }

        private static DocumentType GetDocumentType(DocumentType documentType)
        {
            return documentType switch
            {
                DocumentType.NetsOs => DocumentType.ReceiptNetsOs,
                DocumentType.NetsOsInfo => DocumentType.ReceiptNetsOsInfo,
                DocumentType.Bs601 => DocumentType.ReceiptBs601,
                DocumentType.Xml000 => DocumentType.ReceiptBs601,
                _ => DocumentType.Unknown
            };
        }

        private static string GetContent(string inputFileName, DocumentType documentType)
        {
            var baseText = inputFileName + " received successfully.";
            var enhancedText = documentType + " " + baseText;
            return documentType switch
            {
                DocumentType.NetsOs => enhancedText,
                DocumentType.NetsOsInfo => enhancedText,
                DocumentType.Bs601 => enhancedText,
                DocumentType.Xml000 => enhancedText,
                _ => baseText
            };
        }

        private static string GetOutputFileName(string inputFileName)
        {
            if (inputFileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                inputFileName = inputFileName.Substring(0, inputFileName.Length - 4);
            }
            return inputFileName + "_receipt.txt";
        }
    }
}
