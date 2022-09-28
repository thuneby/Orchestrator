using Core.CoreModels;
using Core.OrchestratorModels;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utilities.Ftp;

namespace Transfer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController: ControllerBase
    {
        private const string FtpFolder = @"";

        private readonly ParameterRepository _parameterRepository;
        private readonly OutputFileRepository _outputFileRepository;
        private readonly FtpControllerFactory _ftpControllerFactory;
        private readonly ILoggerFactory _loggerFactory;
        private ILogger<TransferController> _logger;

        public TransferController(ParameterRepository parameterRepository, OutputFileRepository outputFileRepository, FtpControllerFactory ftpControllerFactory, ILoggerFactory loggerFactory)
        {
            _parameterRepository = parameterRepository;
            _outputFileRepository = outputFileRepository;
            _ftpControllerFactory = ftpControllerFactory;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger<TransferController>();
        }

        [HttpPost("[Action]")]
        public async Task<string> TransferToRecipient(EventEntity entity) 
        {
            var count = 0;
            var outputFiles = await _outputFileRepository.GetOutputFiles(entity.FlowId);
            if (!outputFiles.Any())
                return count + " files uploaded";
            var settings = GetSettings(entity.TenantÍd);
            var ftpController = _ftpControllerFactory.GetController(settings, _loggerFactory);
            var ftpFolder = GetOutputFolder(settings, entity.DocumentType);
            foreach (var outputFile in outputFiles)
            {
                try
                {
                    ftpController.Put(ftpFolder, outputFile.FileName, outputFile.Content);
                    count++;
                }
                catch (Exception e)
                {
                    _logger.LogError("Error uploding file: " + outputFile.FileName + " " + e.Message, e);
                    throw;
                }
            }
            return count + " file(s) uploaded";
        }


        private FtpSettings GetSettings(long tenantId)
        {
            var defaultSettings = new FtpSettings
            {
                RootFolder = FtpFolder,
                BsOutputFolder = "BsOutput",
                OsOutputFolder = "OsOutput"
            };
            var parameters = _parameterRepository.GetParameters(tenantId);
            var fileLoadParameter = parameters.FirstOrDefault(x => x.ParameterType == ParameterType.FileLoadParameters);
            if (fileLoadParameter == null)
                return defaultSettings;
            try
            {
                var settings = JsonConvert.DeserializeObject<FtpSettings>(fileLoadParameter.Value);
                if (settings != null)
                    return settings;
            }
            catch (Exception e)
            {
                _logger.LogError("Error deserializing FtpSettings " + e.Message, e);
            }

            return defaultSettings;
        }

        private static string GetOutputFolder(FtpSettings settings, DocumentType documentType)
        {
            return documentType switch
            {
                DocumentType.NetsOs => settings.OsOutputFolder,
                DocumentType.NetsOsInfo => settings.OsOutputFolder,
                DocumentType.Bs601 => settings.BsOutputFolder,
                DocumentType.Xml000 => settings.BsOutputFolder,
                _ => throw new ArgumentOutOfRangeException(nameof(documentType), documentType, null)
            };
        }
    }
}
