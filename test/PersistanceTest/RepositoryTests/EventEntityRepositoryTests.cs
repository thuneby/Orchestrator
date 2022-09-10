using Core.Models;
using DataAccess.DataAccess;
using FluentAssertions;
using PersistanceTest.Common;

namespace PersistanceTest.RepositoryTests
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
            Initialize();
            _repository = new EventRepository(Context, TestLoggerFactory);
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
