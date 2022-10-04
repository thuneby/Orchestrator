using Dapr.Client;

namespace ServiceInvocation.Extensions
{
    public class ServiceInvoker
    {
        public static async Task<T2> InvokeService<T1, T2>(HttpMethod method, string appId, string methodName, T1 entity)
        {
            var cancellationToken = new CancellationTokenSource().Token;
            using var client = new DaprClientBuilder().Build();
            var request = client.CreateInvokeMethodRequest(method, appId, methodName, entity);
            var result = await client.InvokeMethodAsync<T2>(request, cancellationToken);
            return result;
        }
    }
}
