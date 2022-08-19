using Microsoft.Extensions.Logging;
using Orchestrator.Core.Models;
using Orchestrator.Persistance.Common;
using Orchestrator.Persistance.Models;

namespace Orchestrator.Persistance.DataAccess
{
    public class EventRepository : GuidRepositoryBase<EventEntity>, IGuidRepository<EventEntity>
    {
        public EventRepository(OrchestratorContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
