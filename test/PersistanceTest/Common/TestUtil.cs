using BlobAccess.DataAccessLayer.Helpers;
using BlobAccess.Models;
using Core.Models;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace PersistanceTest.Common
{
    internal class TestUtil
    {
        private static readonly string TestData = Path.Combine("TestData");

        public static async Task<Guid> UploadFileToStorage(string fileName, string testDataFolder, IStorageHelper helper, DocumentType documentType)
        {

            var fullPath = Path.Combine(TestData, testDataFolder, fileName);
            //var fileInfo = new FileInfo(fullPath);
            Guid fileId;
            await using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            {
                fileId = await helper.UploadFile(stream, fileName, documentType);
            }

            return fileId;
        }

        public static async Task<Stream> GetFileStream(string fileName, string testDataFolder)
        {
            var fullPath = Path.Combine(TestData, testDataFolder, fileName);
            var fileInfo = new FileInfo(fullPath);
            var content = new byte[fileInfo.Length];
            await using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            {
                await stream.ReadAsync(content.AsMemory(0, (int)fileInfo.Length));
            }
            return new MemoryStream(content);
        }

        public static IOptions<AzureStorageConfig> InitializeAzureConfig()
        {
            var config = new AzureStorageConfig
            {
                AccountName = "",
                FileContainer = "",
                BlobContainer = "",
                ConnectionString = "",
                NameSpace = ""
            };

            return new OptionsWrapper<AzureStorageConfig>(config);
        }

    }
}
