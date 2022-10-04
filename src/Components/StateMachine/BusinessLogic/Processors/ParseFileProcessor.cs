using Core.OrchestratorModels;
using Microsoft.Extensions.Logging;
using Parse.Controllers;
using ServiceInvocation.Extensions;
using StateMachine.Abstractions;

namespace StateMachine.BusinessLogic.Processors
{
    internal class ParseFileProcessor: IProcessor
    {
        private readonly ParseController _controller;
        private readonly ILogger<ParseFileProcessor> _logger;

        public ParseFileProcessor(ParseController controller, ILoggerFactory loggerFactory)
        {
            _controller = controller;
            _logger = loggerFactory.CreateLogger<ParseFileProcessor>();
        }

        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                //var id = Guid.Parse(entity.Parameters);
                //var documentId = await _controller.ParseFromGuid(id, entity.DocumentType, entity.TenantÍd);
                var documentId = await ServiceInvoker.InvokeService<EventEntity, Guid>(HttpMethod.Post, "parse", "parse/ParseFromEvent", entity);
                entity.Result = documentId.ToString();
                entity.UpdateProcessResult();
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
