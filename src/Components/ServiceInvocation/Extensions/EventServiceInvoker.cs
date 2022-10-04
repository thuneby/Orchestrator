using Core.OrchestratorModels;

namespace ServiceInvocation.Extensions
{
    public class EventServiceInvoker 
    {
        public static async Task<EventEntity> InvokeService(HttpMethod method, string appId, string methodName, EventEntity entity)
        {
            var result = await ServiceInvoker.InvokeService<EventEntity, EventEntity>(method, appId, methodName, entity);
            entity.AssignResult(result);
            return entity;
        }
    }
}
