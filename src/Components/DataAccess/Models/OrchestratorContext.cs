using Core.Models;
using Core.OrchestratorModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models
{
    public class OrchestratorContext : DbContext
    {
        public OrchestratorContext(DbContextOptions<OrchestratorContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<EventEntity> EventEntity { get; set; }
        public DbSet<ParameterEntity> ParameterEntity { get; set; }
        public DbSet<Flow> Flow { get; set; }
    }
}
