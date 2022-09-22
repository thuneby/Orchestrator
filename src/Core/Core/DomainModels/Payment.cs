using Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DomainModels
{
    public class Payment: GuidModelBase
    {
        public Payment()
        {
            PaymentDetails = new HashSet<PaymentDetail>();
        }
        
        public Guid DocumentId { get; set; }
        public DocumentType DocumentType { get; set; }
        public ReconcileStatus ReconcileStatus { get; set; }
        public InformationType InformationType { get; set; }

        [Column(TypeName = "Date")]
        public DateTime PaymentDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DueDate { get; set; } 
        
        public Decimal TotalAmount { get; set; }
        public string PaymentReference { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountNumber { get; set; }
        public string DataProviderNumber { get; set; }
        
        [StringLength(8)]
        public string Cvr { get; set; }
        public string PbsNumberRecepient { get; set; }
        public bool Valid { get; set; }

        public ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
