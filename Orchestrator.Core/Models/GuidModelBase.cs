using System.ComponentModel.DataAnnotations.Schema;

namespace Orchestrator.Core.Models
{
    public abstract class GuidModelBase: Entity<Guid>
    {
        public GuidModelBase()
        {
            Id = Guid.NewGuid();
            TenantÍd = 0;
        }

        public GuidModelBase(long tenantÍd)
        {
            TenantÍd = tenantÍd;
            Id = Guid.NewGuid();
        }

        public long TenantÍd { get; set; }

        [ForeignKey("TenantId")]
        [Newtonsoft.Json.JsonIgnore]
        public Tenant Tenant { get; set; }

    }
}
