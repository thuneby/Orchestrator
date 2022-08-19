using FluentAssertions;
using Orchestrator.Core.Models;
using Orchestrator.Persistance.DataAccess;
using Orchestrator.PersistanceTest.Common;

namespace Orchestrator.PersistanceTest.RepositoryTests
{
    public class EventEntityRepositoryTests: TestBase
    {
        private readonly EventRepository _repository;
        
        private readonly EventEntity _eventEntity = new EventEntity()
        {
            EventType = EventType.AddCustomer,
            ProcessState = ProcessState.Receive
        };

        public EventEntityRepositoryTests()
        {
            _repository = new EventRepository(Context, LoggerFactory);
        }
        
        [Fact]
        public void AddEvent()
        {
            // Arrange
            var id = _eventEntity.Id;

            // Act
            _repository.Add(_eventEntity);
            var result = _repository.Get(id);

            // Assert
            result.Should().NotBeNull();
            result.EventType.Should().Be(EventType.AddCustomer);
        }
    }
}
