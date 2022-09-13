using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public abstract class TenantModelBase: LongEntityBase
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
