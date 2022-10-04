namespace ServiceInvocation.Abstractions
{
    internal interface IInvokeService<T1, T2> 
    {
        Task<T2> InvokeService(HttpMethod method, string appId, string methodName, T1 entity);
    }
}
