using Administration.Models;
using BlobAccess.DataAccessLayer.Helpers;
using Core.CoreModels;
using Core.OrchestratorModels;
using Core.QueueModels;
using EventBus.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Administration.Controllers
{
    public class FileController: AlertControllerBase
    {
        private readonly IStorageHelper _storageHelper;
        private readonly IEventBus _eventBus;
        private readonly ILogger<FileController> _logger;

        public FileController(IStorageHelper storageHelper, IEventBus eventBus, ILogger<FileController> logger)
        {
            _storageHelper = storageHelper;
            _eventBus = eventBus;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Upload");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(IFormFile file, int type)
        {
            try
            {
                string message;
                var alertStyle = "";
                var id = Guid.Empty;
                var documentType = (DocumentType)type;
                await using (var stream = file.OpenReadStream())
                {
                    try
                    {
                        id = await _storageHelper.UploadFile(stream, file.FileName, documentType);
                        message = $"Succes! Filen '{file.FileName}' med id {id} er blevet uploadet.";
                        alertStyle = AlertStyles.Success;

                    }
                    catch (Exception e)
                    {
                        message = e.Message.Contains("blob already exists") ? $"Fejl! Filen '{file.FileName}' findes allerede." : e.Message + e.InnerException?.Message;
                        alertStyle = AlertStyles.Danger;
                    }
                    try
                    {
                        var queueMessage = new QueueMessage(id, documentType, ProcessState.Receive, file.FileName);
                        await _eventBus.PublishAsync(queueMessage, Topics.FileUploadedTopicName);
                        _logger.LogInformation($"File with id {id} published!");
                    }
                    catch (Exception e)
                    {
                        message = "ERROR Publishing integration event: " + id + " from Upload" + e.Message + e.InnerException?.Message;
                        _logger.LogError(message);
                        alertStyle = AlertStyles.Danger;
                    }
                }
                return RedirectToAction("Upload", "File", new { message, alertStyle });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Upload")]
        public IActionResult Upload(string message = "", string alertStyle = "")
        {
            if (message == "") return View("Upload");
            GenerateMessage(message, alertStyle);
            return View("Upload");
        }

    }
}
