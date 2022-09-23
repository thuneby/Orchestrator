using Core.CoreModels;

namespace Core.OrchestratorModels
{
    public class Flow : TenantModelBase
    {
        public Flow()
        {
            Events = new List<EventEntity>();
        }

        public FlowState State { get; set; }
        public ICollection<EventEntity> Events { get; set; }
    }
}
