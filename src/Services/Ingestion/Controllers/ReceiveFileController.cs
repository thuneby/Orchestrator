using BlobAccess.DataAccessLayer.Helpers;
using Core.CoreModels;
using Core.OrchestratorModels;
using Core.QueueModels;
using Dapr.Client;
using DataAccess.DataAccess;
using EventBus.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Utilities.Ftp;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
        private readonly ParameterRepository _parameterRepository;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<ReceiveFileController> _logger;

        public ReceiveFileController(FtpControllerFactory ftpControllerFactory, IStorageHelper storageHelper, IEventBus eventBus, ParameterRepository parameterRepository, ILoggerFactory loggerFactory)
        {
            _ftpControllerFactory = ftpControllerFactory;
            _storageHelper = storageHelper;
            _eventBus = eventBus;
            _parameterRepository = parameterRepository;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger<ReceiveFileController>();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> ReceiveFiles(long tenantId, DocumentType documentType)
        {
            var fileCount = 0;
            var settings = await GetSettings(tenantId);
            var ftpController = _ftpControllerFactory.GetController(settings, _loggerFactory);
            var ftpFolder = GetInputFolder(settings, documentType);
            var fileList = ftpController.GetFileList(ftpFolder);
            if (fileList.Count == 0)
                return new ObjectResult("No files to download!");
            foreach (var file in fileList)
            {
                var inputFile = ftpController.Get(file, ftpFolder);
                if (inputFile == null)
                    continue;
                inputFile.TenantÍd = tenantId;
                inputFile.DocumentType = documentType;
                using var stream = new MemoryStream(inputFile.Content);
                var id = await _storageHelper.UploadFile(stream, inputFile.FileName, documentType);
                fileCount++;
                inputFile.Content = Array.Empty<byte>();
                var payload = JsonConvert.SerializeObject(inputFile, new StringEnumConverter());
                var message = new QueueMessage(id, documentType, ProcessState.Receive, inputFile.FileName, payload);
                // raise event 
                await _eventBus.PublishAsync(message, Topics.FileUploadedTopicName);
                _logger.LogInformation($"File with id {id} published!");
                //ftpController.DeleteFile(inputFile.FileName, ftpFolder); // ToDo Uncomment this!
            }
            fileList.Add(fileCount + " files uploaded");
            return new ObjectResult(fileList);
        }

        [HttpPost("[action]")]
        public async Task<EventEntity> ExecuteReceiveEvent(EventEntity entity)  
        {
            try
            {
                var settings = await GetSettings(entity.TenantÍd);
                var ftpController = _ftpControllerFactory.GetController(settings, _loggerFactory);
                var ftpFolder = GetInputFolder(settings, entity.DocumentType);
                var inputFile = ftpController.Get(entity.Parameters, ftpFolder);
                if (inputFile == null)
                {
                    var errorMessage = $"File with filename '{entity.Parameters}' not found";
                    throw new ArgumentException(errorMessage);
                }
                inputFile.TenantÍd = entity.TenantÍd;
                inputFile.DocumentType = entity.DocumentType;
                inputFile.FlowId = entity.FlowId;
                using var stream = new MemoryStream(inputFile.Content);
                var id = await _storageHelper.UploadFile(stream, inputFile.FileName, inputFile.DocumentType);
                entity.Result = id.ToString();
                entity.UpdateProcessResult();
                //ftpController.DeleteFile(inputFile.FileName, ftpFolder); // ToDo: Uncomment this!
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
        public async Task<List<string>> GetFileList(long tenantId, DocumentType documentType)
        {
            var settings = await GetSettings(tenantId);
            var ftpController = _ftpControllerFactory.GetController(settings, _loggerFactory);
            var fileList = ftpController.GetFileList(GetInputFolder(settings, documentType));
            return fileList;
        }

        private async Task<FtpSettings> GetSettings(long tenantId)
        {
            var defaultSettings = new FtpSettings
            {
                RootFolder = FtpFolder,
                BsInputFolder = "BsInput",
                OsInputFolder = "OsInput"
            };
            var parameters = await GetParameters(tenantId);

            var fileLoadParameter = parameters.FirstOrDefault(x => x.ParameterType == ParameterType.FileLoadParameters);
            if (fileLoadParameter == null)
                return defaultSettings;
            try
            {
                var settings = JsonConvert.DeserializeObject<FtpSettings>(fileLoadParameter.Value);
                if (settings != null)
                    return settings;
            }
            catch(Exception e)
            {
                _logger.LogError("Error deserializing FtpSettings " + e.Message, e);
            }

            return defaultSettings;
        }

        private async Task<ICollection<ParameterEntity>> GetParameters(long tenantId)
        {
            const string DAPR_STORE_NAME = "statestore";
            using var client = new DaprClientBuilder().Build();
            var result = await client.GetStateAsync<string>(DAPR_STORE_NAME, tenantId.ToString());
            if (!string.IsNullOrWhiteSpace(result))
            {
                var parameterEntities = JsonSerializer.Deserialize<List<ParameterEntity>>(result);
                return parameterEntities?? new List<ParameterEntity>();
            }
            var parameters = _parameterRepository.GetParameters(tenantId).ToList();
            return parameters;
        }

        private static string GetInputFolder(FtpSettings settings, DocumentType documentType)
        {
            return documentType switch
            {
                DocumentType.NetsOs => settings.OsInputFolder,
                DocumentType.NetsOsInfo => settings.OsInputFolder,
                DocumentType.Bs601 => settings.BsInputFolder,
                DocumentType.Xml000 => settings.BsInputFolder,
                _ => throw new ArgumentOutOfRangeException(nameof(documentType), documentType, null)
            };
        }
    }
}
