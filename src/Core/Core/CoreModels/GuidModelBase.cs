namespace Core.CoreModels
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

    }
}
