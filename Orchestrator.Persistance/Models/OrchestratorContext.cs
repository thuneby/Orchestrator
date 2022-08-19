using Microsoft.EntityFrameworkCore;
using Orchestrator.Core.Models;

namespace Orchestrator.Persistance.Models
{
    public class OrchestratorContext: DbContext
    {
        public OrchestratorContext(DbContextOptions<OrchestratorContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<EventEntity> EventEntity { get; set; }
        public DbSet<ParameterEntity> ParameterEntity { get; set; }
        public DbSet<Flow> Flow { get; set; }
    }
}
