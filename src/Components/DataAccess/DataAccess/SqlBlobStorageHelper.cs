using BlobAccess.DataAccessLayer.Helpers;
using Core.Models;
using System.Data;

namespace DataAccess.DataAccess
{
    public class SqlBlobStorageHelper: IStorageHelper
    {
        private readonly InputFileRepository _repository;

        public SqlBlobStorageHelper(InputFileRepository inputFileRepository)
        {
            _repository = inputFileRepository;
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
            try
            {
                var file = await _repository.Get(fileName);
                return file == null ? Stream.Null : new MemoryStream(file.Content);
            }
            catch (Exception exception)
            {
                throw new DataException("Fil med navn " + fileName + " ikke fundet!", exception);
            }
        }

        public async Task<Stream> GetPayload(Guid id)
        {
            try
            {
                var file = _repository.Get(id);
                await Task.FromResult(true);
                return file == null ? Stream.Null : new MemoryStream(file.Content);
            }
            catch (Exception exception)
            {
                throw new DataException("Fil med  id " + id + " ikke fundet!", exception);
            }
        }

        public async Task<bool> DeleteFile(string fileName)
        {
            var file = await _repository.Get(fileName);
            if (file == null)
                return false;
            _repository.Delete(file.Id);
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
