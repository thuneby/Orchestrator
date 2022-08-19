using Microsoft.Extensions.Logging;
using Orchestrator.Core.Models;
using Orchestrator.Persistance.Models;

namespace Orchestrator.Persistance.DataAccess
{
    public class SagaRepository: ModelRepositoryBase<Saga>
    {
        public SagaRepository(OrchestratorContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
