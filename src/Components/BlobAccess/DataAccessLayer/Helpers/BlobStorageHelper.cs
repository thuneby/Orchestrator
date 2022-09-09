using Azure.Identity;
using Azure.Storage.Blobs;
using BlobAccess.Models;
using Core.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BlobAccess.DataAccessLayer.Helpers
{
    public class BlobStorageHelper: IStorageHelper
    {
        private readonly AzureStorageConfig _config;
        private readonly IHostEnvironment _hostEnvironment;

        public BlobStorageHelper(IOptions<AzureStorageConfig> config, IHostEnvironment hostEnvironment)
        {
            _config = config.Value;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<Guid> UploadFile(Stream fileStream, string fileName, DocumentType documentType)
        {
            //await container.CreateAsync();
            var containerClient = GetClient();

            // Get a reference to a blob named "sample-file" in a container named "sample-container"
            var id = Guid.NewGuid();
            var blob = containerClient.GetBlobClient(id.ToString());

            // Upload local file
            await blob.UploadAsync(fileStream);
            await AddBlobMetadataAsync(blob, documentType);
            return id;
        }

        public async Task<Stream> GetPayload(string fileName)
        {
            var containerClient = GetClient();
            var blob = containerClient.GetBlobClient(fileName);
            var stream = new MemoryStream();
            if (blob.Exists())
            {
                await blob.DownloadToAsync(stream);
            }

            stream.Position = 0;
            return stream;
        }

        public async Task<bool> DeleteFile(string fileName)
        {
            var containerClient = GetClient();
            var blob = containerClient.GetBlobClient(fileName);
            if (!await blob.ExistsAsync()) return false;
            await blob.DeleteAsync();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<string>> GetFileList()
        {
            var containerClient = GetClient();
            var list = new List<string>();
            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                list.Add(blobItem.Name);
            }
            return list;

        }

        private BlobContainerClient GetClient()
        {
            if (_config.AccountName == string.Empty)
                throw new AccessViolationException("sorry, can't retrieve your azure storage details from appsettings.json, make sure that you add azure storage details there");
            if (_config.BlobContainer == string.Empty)
                throw new ArgumentException("Please provide a name for your file container in the azure blob storage");
            if (string.IsNullOrEmpty(_config.ConnectionString) || !(_hostEnvironment.EnvironmentName.Equals("DeveloperSqlServer")|| _hostEnvironment.EnvironmentName.Equals("Development")))
                return GetClient(_config.AccountName, _config.BlobContainer);
            var containerClient = new BlobContainerClient(_config.ConnectionString, _config.BlobContainer);
            return containerClient;
        }

        public BlobContainerClient GetClient(string accountName, string containerName) 
        {
            // Construct the blob container endpoint from the arguments.
            var containerEndpoint = string.Format("https://{0}.blob.core.windows.net/{1}",accountName, containerName);

            // Get a credential and create a client object for the blob container.
            var containerClient = new BlobContainerClient(new Uri(containerEndpoint), new DefaultAzureCredential());
            return containerClient;
        }

        private static async Task AddBlobMetadataAsync(BlobClient blob, DocumentType documentType)
        {
            IDictionary<string, string> metadata = new Dictionary<string, string>
            {

                // Add metadata to the dictionary by calling the Add method
                { "documentType", documentType.ToString() }
            };

            // Set the blob's metadata.
            await blob.SetMetadataAsync(metadata);
        }
    }
}
