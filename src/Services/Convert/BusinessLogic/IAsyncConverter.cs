namespace Convert.BusinessLogic
{
    public interface IAsyncConverter
    {
        Task<Guid> Convert(Guid fileId, long tenantId);
    }
}
