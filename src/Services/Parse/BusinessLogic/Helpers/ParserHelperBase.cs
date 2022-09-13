using BlobAccess.DataAccessLayer.Helpers;
using Core.Models;
using FileHelpers;

namespace Parse.BusinessLogic.Helpers
{
    public abstract class TextParserHelperBase<T>
        where T : TextModelBase
    {
        public async Task<(IEnumerable<T>, List<string>)> GetRecordsFromPayload(Guid guid, IStorageHelper storageHelper, DocumentType documentType)
        {
            var errors = new HashSet<string>();
            var payload = await storageHelper.GetPayload(guid.ToString());
            var engine = new FileHelperEngine<T>();
            engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;
            var records = engine.ReadStream(new StreamReader(payload, EncodingHelper.GetEncoding(documentType)));
            if (engine.ErrorManager.HasErrors)
                foreach (var error in engine.ErrorManager.Errors)
                {
                    errors.Add(error.ExceptionInfo.Message);
                }
            var errorList = errors.ToList();
            return (records, errorList);
        }
    }
}
