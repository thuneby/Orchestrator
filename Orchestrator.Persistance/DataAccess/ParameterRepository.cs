using Microsoft.Extensions.Logging;
using Orchestrator.Core.Models;
using Orchestrator.Persistance.Common;
using Orchestrator.Persistance.Models;

namespace Orchestrator.Persistance.DataAccess
{
    public class ParameterRepository: GuidRepositoryBase<ParameterEntity>, IGuidRepository<ParameterEntity>
    {
        public ParameterRepository(OrchestratorContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
