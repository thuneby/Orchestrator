using Core.OrchestratorModels;
using Microsoft.Extensions.Logging;
using ServiceInvocation.Extensions;
using StateMachine.Abstractions;

namespace StateMachine.BusinessLogic.Processors
{
    public class ConvertDocumentProcessor: IProcessor
    {
        private readonly ILogger<ConvertDocumentProcessor> _logger;

        public ConvertDocumentProcessor(ILoggerFactory loggerFactory
        )
        {
            _logger = loggerFactory.CreateLogger<ConvertDocumentProcessor>();
        }

        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                //var documentId = await _controller.ConvertDocument(entity);
                var documentId = await ServiceInvoker.InvokeService<EventEntity, Guid>(HttpMethod.Post, "convert", "conversion/ConvertDocument", entity);
                if (documentId != Guid.Empty)
                {
                    entity.Result = documentId.ToString();
                    entity.UpdateProcessResult();
                }
                else
                {
                    entity.ErrorMessage = "Unable to convert document with Id " + entity.Parameters;
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
