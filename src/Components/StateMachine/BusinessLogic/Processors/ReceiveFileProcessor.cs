using Core.OrchestratorModels;
using Dapr.Client;
using Ingestion.Controllers;
using Microsoft.Extensions.Logging;
using StateMachine.Abstractions;

namespace StateMachine.BusinessLogic.Processors
{
    public class ReceiveFileProcessor: IProcessor
    {
        private readonly ReceiveFileController _controller;
        private readonly ILogger<ReceiveFileProcessor> _logger;

        public ReceiveFileProcessor(ReceiveFileController controller, ILogger<ReceiveFileProcessor> logger)
        {
            _controller = controller;
            _logger = logger;
        }

        public async Task<EventEntity> ProcessEvent(EventEntity entity)
        {
            try
            {
                //entity = await _controller.ExecuteReceiveEvent(entity);
                entity = await ExecuteEvent(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                entity.ErrorMessage = e.Message;
                entity.UpdateProcessResult(EventState.Error);
            }

            return entity;
        }

        private static async Task<EventEntity> ExecuteEvent(EventEntity entity)
        {
            var source = new CancellationTokenSource();
            var cancellationToken = source.Token;
            using var client = new DaprClientBuilder().Build();
            var request = client.CreateInvokeMethodRequest(HttpMethod.Post, "ingestion", "receivefile/ExecuteReceiveEvent", entity);
            var result = await client.InvokeMethodAsync<EventEntity>(request, cancellationToken);
            entity.AssignResult(result);
            return entity;
        }


    }
}
