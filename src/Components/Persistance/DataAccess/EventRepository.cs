using Core.Models;
using DataAccess.Common;
using DataAccess.Models;
using Microsoft.Extensions.Logging;

namespace DataAccess.DataAccess
{
    public class EventRepository : GuidRepositoryBase<EventEntity>, IGuidRepository<EventEntity>
    {
        private readonly OrchestratorContext _context;
        public EventRepository(OrchestratorContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
            _context = context;
        }

        public void AddOrUpdateEventEntity(EventEntity eventEntity)
        {

        }
    }
}
