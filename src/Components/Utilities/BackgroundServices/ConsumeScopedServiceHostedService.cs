using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Utilities.BackgroundServices
{
    public class ConsumeScopedServiceHostedService : BackgroundService
    {
        private readonly ILogger<ConsumeScopedServiceHostedService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public ConsumeScopedServiceHostedService(IServiceScopeFactory scopeFactory, ILogger<ConsumeScopedServiceHostedService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //_logger.LogInformation("Consume Scoped Service Hosted Service running.");
            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            //_logger.LogInformation("Consume Scoped Service Hosted Service is working.");
            using (var scope = _scopeFactory.CreateScope())
            {
                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IScopedProcessingService>();
                while (!stoppingToken.IsCancellationRequested)
                {
                    await scopedProcessingService.DoWork(stoppingToken);
                }
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service is stopping.");

            await Task.CompletedTask;
        }
    }

}
