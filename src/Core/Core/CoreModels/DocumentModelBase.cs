using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public abstract class DocumentModelBase : Entity<string>
    {
        protected DocumentModelBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        [ForeignKey("TenantId")]
        public long TenantId { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public Tenant Tenant { get; set; }
    }
}
