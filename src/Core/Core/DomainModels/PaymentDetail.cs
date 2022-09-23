using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.CoreModels;

namespace Core.DomainModels
{
    public class PaymentDetail: GuidModelBase
    {
        [Required]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime FromDate { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime ToDate { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "Cvr")]
        public string Cvr { get; set; }

        public int SequenceNumber { get; set; }

        [Required]
        [StringLength(11)]
        public string Cpr { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N}")]
        public decimal Amount { get; set; }

        [Required]
        public PaymentDetailType PaymentDetailType { get; set; }
        public string CustomerNumberSender { get; set; }
        public string CustumerNumberRecepient { get; set; }

    }
}
