using System.Text.Json;
using Dapr.Client;
using DataAccess.Models;

namespace Orchestrator
{
    public static class ProgramExtensions
    {
        public static async void AddCaching(this WebApplication app)
        {
            const string DAPR_STORE_NAME = "statestore";
            using var client = new DaprClientBuilder().Build();
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<OrchestratorContext>();
            var parameters = context.ParameterEntity.ToList();
            var tenantParameters = parameters.GroupBy(x => x.TenantÍd)
                .Select( param => new 
                {
                    param.Key,
                    Parameters = param.ToList()
                });
            foreach (var tenant in tenantParameters)
            {
                var tenantId = tenant.Key;
                var value = JsonSerializer.Serialize(tenant.Parameters);
                await client.SaveStateAsync(DAPR_STORE_NAME, tenantId.ToString(), value);
            }
        }
    }
}
