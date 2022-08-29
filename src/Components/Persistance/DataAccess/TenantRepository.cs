using Core.Models;
using Microsoft.Extensions.Logging;
using Persistance.Common;
using Persistance.Models;

namespace Persistance.DataAccess
{
    public class TenantRepository: ModelRepositoryBase<Tenant>, IRepository<Tenant, long>
    {
        public TenantRepository(OrchestratorContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
