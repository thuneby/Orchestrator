using Microsoft.Extensions.Logging;
using Orchestrator.Core.Models;
using Orchestrator.Persistance.Common;
using Orchestrator.Persistance.Models;

namespace Orchestrator.Persistance.DataAccess
{
    public class TenantRepository: ModelRepositoryBase<Tenant>, IRepository<Tenant, long>
    {
        public TenantRepository(OrchestratorContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
