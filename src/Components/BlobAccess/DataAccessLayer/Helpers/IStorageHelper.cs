using Core.CoreModels;

namespace BlobAccess.DataAccessLayer.Helpers
{
    public interface IStorageHelper
    {
        Task<Guid> UploadFile(Stream fileStream, string fileName, DocumentType documentType);
        Task<Stream> GetPayload(string fileName);
        Task<Stream> GetPayload(Guid id);
        Task<bool> DeleteFile(string fileName);
        Task<IEnumerable<string>> GetFileList();

    }
}
