namespace Core.Models
{
    public class Flow: TenantModelBase
    {
        public Flow()
        {
            Events = new List<EventEntity>();
        }
        public ICollection<EventEntity> Events { get; set; }
    }
}
