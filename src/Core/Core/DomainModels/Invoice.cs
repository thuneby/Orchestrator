using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.CoreModels;

namespace Core.DomainModels
{
    public class Invoice: GuidModelBase
    {
        public Guid DocumentId { get; set; }
        public DocumentType DocumentType { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FromDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ToDate { get; set; }

        [StringLength(11)]
        public string Cpr { get; set; }

        [StringLength(8)]
        public string Cvr { get; set; }

        [StringLength(35)]
        public string CustomerName { get; set; }

        [StringLength(15)]
        public string CustomerNumber { get; set; }
        [StringLength(35)]
        public string Address1 { get; set; }

        [StringLength(35)]
        public string Address2 { get; set; }

        [StringLength(35)]
        public string City { get; set; }
        [StringLength(4)]
        public string PostalCode { get; set; }
        [StringLength(3)]
        public string Country { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DueDate { get; set; }
        public int PolicyNumber { get; set; }
        public int NetsAgreementNumber { get; set; }
        public ReconcileStatus ReconcileStatus { get; set; } 
        public bool Rejected { get; set; }

        [StringLength(30)]
        public string Reference { get; set; }

        [StringLength(60)]
        public string TextLine { get; set; }
        public bool Expedited { get; set; }
        public bool PrintAndSend { get; set; }
    }
}
