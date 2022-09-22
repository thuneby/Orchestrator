using Core.Models;
using Core.OrchestratorModels;
using Core.QueueModels;
using EventBus.Abstractions;
using PersistanceTest.Common;

namespace PersistanceTest.EventBus
{
    public class RedisEventBusTests: TestBase
    {
        private IEventBus _eventBus;

        public RedisEventBusTests()
        {
            Initialize();
        }
        
        [Fact(Skip = "Requires EventBus")]
        // Requirres eventBus
        public void PublishEvent()
        {
            //_eventBus = new RedisEventBus(TestLoggerFactory.CreateLogger<RedisEventBus>());
            var message = new QueueMessage(Guid.NewGuid(), DocumentType.NetsOsInfo, ProcessState.Receive,
                "testfile.txt", "");
        }
    }
}
