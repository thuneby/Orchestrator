using BlobAccess.DataAccessLayer.Helpers;
using Core.Models;
using Core.QueueModels;
using EventBus.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Utilities.Ftp;

namespace Ingestion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceiveFileController : ControllerBase
    {
        private const string FtpFolder = @"C:\Ftp\Orchestrator";
        private readonly IFtpController _ftpController;
        private readonly IStorageHelper _storageHelper;
        private readonly IEventBus _eventBus;
        private readonly ILogger<FtpController> _logger;

        public ReceiveFileController(IFtpController ftpController, IStorageHelper storageHelper, IEventBus eventBus, ILogger<FtpController> logger)
        {
            _ftpController = ftpController;
            _ftpController.SetRootFolder(FtpFolder);
            _storageHelper = storageHelper;
            _eventBus = eventBus;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> ReceiveFiles(string ftpFolder, long tenantId)
        {
            var fileCount = 0;
            var fileList = _ftpController.GetFileList(ftpFolder);
            if (fileList.Count == 0)
                return new ObjectResult("No files to download!");
            foreach (var file in fileList)
            {
                var documentType = GetDocumentType(ftpFolder, tenantId);
                var inputFile = _ftpController.Get(file, ftpFolder);
                inputFile.TenantÍd = tenantId;
                inputFile.DocumentType = documentType;
                using var stream = new MemoryStream(inputFile.Content);
                var id = await _storageHelper.UploadFile(stream, inputFile.Id.ToString(), documentType);
                fileCount++;
                inputFile.Content = Array.Empty<byte>();
                var payload = JsonConvert.SerializeObject(inputFile, new StringEnumConverter());
                var message = new QueueMessage(id, documentType, ProcessState.Receive, inputFile.FileName, payload);
                // raise event 
                await _eventBus.PublishAsync(message, Topics.FileUploadedTopicName);
                _logger.LogInformation($"File with id {id} published!");
                _ftpController.DeleteFile(inputFile.FileName, ftpFolder);
            }
            fileList.Add(fileCount + " files uploaded");
            return new ObjectResult(fileList);
        }

        private DocumentType GetDocumentType(string ftpFolder, long tenantId)
        {
            return DocumentType.NetsOsInfo;
        }
    }
}
