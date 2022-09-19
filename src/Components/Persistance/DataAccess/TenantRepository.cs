using Core.Models;
using DataAccess.Abstractions;
using DataAccess.Models;
using Microsoft.Extensions.Logging;

namespace DataAccess.DataAccess
{
    public class TenantRepository : ModelRepositoryBase<Tenant>, IRepository<Tenant, long>
    {
        public TenantRepository(OrchestratorContext context, ILogger<TenantRepository> logger) : base(context, logger)
        {
        }
    }
}
