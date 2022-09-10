using Core.Models;
using DataAccess.Common;
using DataAccess.Models;
using Microsoft.Extensions.Logging;

namespace DataAccess.DataAccess
{
    public class EventRepository : GuidRepositoryBase<EventEntity>, IGuidRepository<EventEntity>
    {
        public EventRepository(OrchestratorContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
