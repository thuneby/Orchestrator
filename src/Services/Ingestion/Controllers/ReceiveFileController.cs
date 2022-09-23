using BlobAccess.DataAccessLayer.Helpers;
using Core.CoreModels;
using Core.OrchestratorModels;
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
        private readonly FtpControllerFactory _ftpControllerFactory;
        private readonly IStorageHelper _storageHelper;
        private readonly IEventBus _eventBus;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<ReceiveFileController> _logger;

        public ReceiveFileController(FtpControllerFactory ftpControllerFactory, IStorageHelper storageHelper, IEventBus eventBus, ILoggerFactory loggerFactory)
        {
            _ftpControllerFactory = ftpControllerFactory;
            _storageHelper = storageHelper;
            _eventBus = eventBus;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger<ReceiveFileController>();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> ReceiveFiles(string ftpFolder, long tenantId)
        {
            var fileCount = 0;
            var ftpController = _ftpControllerFactory.GetController(GetSettings(tenantId), _loggerFactory);
            var fileList = ftpController.GetFileList(ftpFolder);
            if (fileList.Count == 0)
                return new ObjectResult("No files to download!");
            foreach (var file in fileList)
            {
                var documentType = GetDocumentType(ftpFolder, tenantId);
                var inputFile = ftpController.Get(file, ftpFolder);
                if (inputFile == null)
                    continue;
                inputFile.TenantÍd = tenantId;
                inputFile.DocumentType = documentType;
                using var stream = new MemoryStream(inputFile.Content);
                var id = await _storageHelper.UploadFile(stream, inputFile.Id.ToString(), documentType);
                fileCount++;
                inputFile.Content = Array.Empty<byte>();
                var payload = JsonConvert.SerializeObject(inputFile, new StringEnumConverter());
                var message = new QueueMessage(id, documentType, ProcessState.Parse, inputFile.FileName, payload);
                // raise event 
                await _eventBus.PublishAsync(message, Topics.FileUploadedTopicName);
                _logger.LogInformation($"File with id {id} published!");
                ftpController.DeleteFile(inputFile.FileName, ftpFolder);
            }
            fileList.Add(fileCount + " files uploaded");
            return new ObjectResult(fileList);
        }

        [HttpPost("[action]")]
        public async Task<EventEntity> ExecuteReceiveEvent(EventEntity entity)  
        {
            try
            {
                var settings = GetSettings(entity.TenantÍd);
                var ftpController = _ftpControllerFactory.GetController(settings, _loggerFactory);
                var inputFile = ftpController.Get(entity.Parameters, settings.InputFolder);
                if (inputFile == null)
                    throw new ArgumentException(@"File with filename {0} not found", entity.Parameters);
                inputFile.TenantÍd = entity.TenantÍd;
                inputFile.DocumentType = entity.DocumentType;
                using var stream = new MemoryStream(inputFile.Content);
                var id = await _storageHelper.UploadFile(stream, inputFile.Id.ToString(), inputFile.DocumentType);
                entity.Result = id.ToString();
                entity.UpdateProcessResult();
                ftpController.DeleteFile(inputFile.FileName, settings.InputFolder);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                entity.ErrorMessage = e.Message;
                entity.UpdateProcessResult(EventState.Error);
            }
            return entity;
        }

        [HttpGet("[action]")]
        public List<string> GetFileList(long tenantId)
        {
            var settings = GetSettings(tenantId);
            var ftpController = _ftpControllerFactory.GetController(settings, _loggerFactory);
            var fileList = ftpController.GetFileList(settings.InputFolder);
            return fileList;
        }

        private DocumentType GetDocumentType(string ftpFolder, long tenantId)
        {
            return DocumentType.NetsOsInfo;
        }

        private FtpSettings GetSettings(long tenantId)
        {
            return new FtpSettings
            {
                RootFolder = FtpFolder,
                InputFolder = "Input"
            };
        }
    }
}
