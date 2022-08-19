using Microsoft.Extensions.Logging;
using Orchestrator.Core.Models;
using Orchestrator.Persistance.Common;
using Orchestrator.Persistance.Models;

namespace Orchestrator.Persistance.DataAccess
{
    public class FlowRepository: ModelRepositoryBase<Flow>, IRepository<Flow, long>
    {
        public FlowRepository(OrchestratorContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
