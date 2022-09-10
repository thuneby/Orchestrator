using BlobAccess.DataAccessLayer.Helpers;
using Core.Models;
using Microsoft.Extensions.Logging;
using PersistanceTest.TestStorage;
using System.Data;

namespace PersistanceTest.Common
{
    public class TestStorageHelper : IStorageHelper
    {
        private readonly TestStorageRepository _repository;

        public TestStorageHelper(TestStorageContext context, ILoggerFactory loggerFactory)
        {
            _repository = new TestStorageRepository(context, loggerFactory);
        }

        public async Task<Guid> UploadFile(Stream fileStream, string fileName, DocumentType documentType)
        {
            var content = new byte[fileStream.Length];
            var inputFile = new InputFile
            {
                FileName = fileName,
                DocumentType = documentType,
                Size = fileStream.Length
            };
            await fileStream.ReadAsync(content, 0, (int)fileStream.Length);
            inputFile.Content = content;
            _repository.Add(inputFile);
            return inputFile.Id;
        }

        public async Task<Stream> GetPayload(string fileName)
        {
            var guid = Guid.Parse(fileName);
            try
            {
                var file = _repository.Get(guid);
                await Task.FromResult(true);
                return file == null ? Stream.Null : new MemoryStream(file.Content);
            }
            catch (Exception exception)
            {
                throw new DataException("Fil med  id " + guid + " ikke fundet!", exception);
            }
        }

        public async Task<bool> DeleteFile(string fileName)
        {
            var guid = Guid.Parse(fileName);
            var file = _repository.Get(guid);
            if (file == null)
                return false;
            _repository.Delete(guid);
            await Task.FromResult(true);
            return true;
        }

        public async Task<IEnumerable<string>> GetFileList()
        {
            await Task.FromResult(true);
            return _repository.GetAll().Select(x => x.FileName).ToList();
        }
    }

}
