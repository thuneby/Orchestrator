using Convert.Controllers;
using Core.OrchestratorModels;
using Microsoft.Extensions.Logging;
using StateMachine.Abstractions;

namespace StateMachine.BusinessLogic.Processors
{
    public class ConvertDocumentProcessor: IProcessor
    {
        private readonly ConversionController _controller;
        private ILogger<ConvertDocumentProcessor> _logger;

        public ConvertDocumentProcessor(ConversionController controller, ILoggerFactory loggerFactory
        )
        {
            _controller = controller;
            _logger = loggerFactory.CreateLogger<ConvertDocumentProcessor>();
        }

        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                var id = Guid.Parse(entity.Parameters);
                var documentId = await _controller.ConvertDocument(id, entity.DocumentType, entity.TenantÍd);
                if (documentId != Guid.Empty)
                {
                    entity.Result = documentId.ToString();
                    entity.UpdateProcessResult();
                }
                else
                {
                    entity.ErrorMessage = "Unable to convert document with Id " + id;
                    entity.UpdateProcessResult(EventState.Error);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                entity.ErrorMessage = e.Message;
                entity.UpdateProcessResult(EventState.Error);
            }
            return entity;
        }
    }
}
