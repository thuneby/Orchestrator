using System.ComponentModel.DataAnnotations.Schema;

namespace Orchestrator.Core.Models
{
    public abstract class TenantModelBase: ModelBase
    {
        public TenantModelBase() 
        { 
        }
        public TenantModelBase(long tenantÍd)
        {
            TenantÍd = tenantÍd;
        }

        public long TenantÍd { get; set; }

        [ForeignKey("TenantId")]
        [Newtonsoft.Json.JsonIgnore]
        public virtual Tenant Tenant { get; set; }
    }
}
