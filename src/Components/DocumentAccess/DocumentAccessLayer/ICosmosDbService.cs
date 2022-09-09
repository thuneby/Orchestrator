namespace DocumentAccess.DocumentAccessLayer
{
    public interface ICosmosDbService<T>
    {
        Task<IEnumerable<T>> GetRecordsAsync(string query);
        Task<T> GetRecordAsync(string id);
        Task AddRecordAsync(T ipRecord);
        Task UpdateRecordAsync(string id, T record);
        Task DeleteRecordAsync(string id);
    }
}
