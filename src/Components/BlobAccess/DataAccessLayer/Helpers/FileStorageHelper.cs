using Azure;
using Azure.Storage.Files.Shares;
using BlobAccess.Models;
using Core.Models;
using Microsoft.Extensions.Options;

namespace BlobAccess.DataAccessLayer.Helpers
{
    public class FileStorageHelper: IStorageHelper
    {
        private readonly AzureStorageConfig _config;
        public FileStorageHelper(IOptions<AzureStorageConfig> config)
        {
            _config = config.Value;
        }

        public async Task<Guid> UploadFile(Stream fileStream, string fileName, DocumentType documentType)
        {
            var share = new ShareClient(_config.ConnectionString, _config.FileContainer);
            var directory = share.GetRootDirectoryClient();
            var id = Guid.NewGuid();
            var fileClient = directory.GetFileClient(id.ToString());
            await fileClient.CreateAsync(fileStream.Length);
            await fileClient.UploadRangeAsync(new HttpRange(0, fileStream.Length), fileStream);
            return id;
        }

        public Task<Stream> GetPayload(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetPayload(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetFileList()
        {
            throw new NotImplementedException();
        }
    }
}
