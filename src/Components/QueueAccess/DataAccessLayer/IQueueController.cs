using Core.QueueModels;

namespace QueueAccess.DataAccessLayer
{
    public interface IQueueController
    {
        Task EnQueueMessageAsync(string queueName, QueueMessage message);
        Task<QueueMessage> DeQueueMessageAsync(string queueName);
        Task<long> GetQueueLengthAsync(string queueName);
    }
}
