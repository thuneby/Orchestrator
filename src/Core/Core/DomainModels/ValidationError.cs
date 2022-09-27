using Core.CoreModels;

namespace Core.DomainModels
{
    public class ValidationError : GuidModelBase
    {
        public Guid EntityId { get; set; } 
        public string EntityType { get;set; }
        public ErrorCode ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsFixed { get; set; }
    }
}
