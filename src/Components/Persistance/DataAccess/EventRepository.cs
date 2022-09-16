using Core.Models;
using DataAccess.Common;
using DataAccess.Models;
using Microsoft.Extensions.Logging;

namespace DataAccess.DataAccess
{
    public class EventRepository : GuidRepositoryBase<EventEntity>, IGuidRepository<EventEntity>
    {
        private readonly OrchestratorContext _context;
        public EventRepository(OrchestratorContext context, ILogger<EventRepository> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task AddOrUpdateEventEntity(EventEntity eventEntity)
        {
            var existing = _context.EventEntity.FirstOrDefault(x => x.Id == eventEntity.Id);
            if (existing != null)
            {
                existing = eventEntity;
                Update(existing);
            }
            else
            {
                var flow = new Flow
                {
                    CreatedDate = eventEntity.CreatedDate
                };
                _context.Add(flow);
                eventEntity.Flow = flow;
                Add(eventEntity);
            }
        }
    }
}
