namespace Core.CoreModels
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

        //[ForeignKey("TenantId")]
        //[Newtonsoft.Json.JsonIgnore]
        //public Tenant Tenant { get; set; }
    }
}
