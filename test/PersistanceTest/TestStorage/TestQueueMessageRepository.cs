using Core.OrchestratorModels;
using Core.QueueModels;
using DataAccess.DataAccess;
using Microsoft.Extensions.Logging;

namespace PersistanceTest.TestStorage
{
    internal class TestQueueMessageRepository: GuidRepositoryBase<QueueMessage>
    {
        private readonly TestStorageContext _context;
        public TestQueueMessageRepository(TestStorageContext context, ILogger<TestQueueMessageRepository> logger) : base(context, logger)
        {
            _context = context;
        }

        public QueueMessage? Get(ProcessState queueState)
        {
            var message = _context.QueueMessage.OrderBy(x => x.CreatedDate)
                .FirstOrDefault(x => x.ProcessState == queueState);
            if (message != null)
                Delete(message.Id);
            return message;
        }
    }
}
