using Core.Models;
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
            modelBuilder
                .Entity<EventEntity>()
                .Property(e => e.ProcessState)
                .HasConversion<string>();

            modelBuilder
                .Entity<EventEntity>()
                .Property(e => e.EventType)
                .HasConversion<string>();

            modelBuilder.Entity<ParameterEntity>()
                .Property(e => e.EventType)
                .HasConversion<string>();

            modelBuilder.Entity<ParameterEntity>()
                .Property(e => e.ParameterType)
                .HasConversion<string>();

        }

        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<EventEntity> EventEntity { get; set; }
        public DbSet<ParameterEntity> ParameterEntity { get; set; }
        public DbSet<Flow> Flow { get; set; }
    }
}
