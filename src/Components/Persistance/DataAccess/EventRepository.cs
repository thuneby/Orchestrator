using Core.Models;
using Microsoft.Extensions.Logging;
using Persistance.Common;
using Persistance.Models;

namespace Persistance.DataAccess
{
    public class EventRepository : GuidRepositoryBase<EventEntity>, IGuidRepository<EventEntity>
    {
        public EventRepository(OrchestratorContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
