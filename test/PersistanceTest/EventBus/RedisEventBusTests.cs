using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.QueueModels;
using EventBus.Abstractions;
using EventBus.Extensions;
using Microsoft.Extensions.Logging;
using PersistanceTest.Common;

namespace PersistanceTest.EventBus
{
    public class RedisEventBusTests: TestBase
    {
        private readonly IEventBus _eventBus;

        public RedisEventBusTests()
        {
            Initialize();
            _eventBus = new RedisEventBus(TestLoggerFactory.CreateLogger<RedisEventBus>());
        }

        [Fact]
        public void PublishEvent()
        {
            var message = new QueueMessage(Guid.NewGuid(), DocumentType.NetsOsInfo, ProcessState.Receive,
                "testfile.txt", "");
        }
    }
}
