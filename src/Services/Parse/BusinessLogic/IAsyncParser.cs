namespace Parse.BusinessLogic
{
    public interface IAsyncParser
    {
        Task<Guid> Parse(Guid fileId);
    }
}
