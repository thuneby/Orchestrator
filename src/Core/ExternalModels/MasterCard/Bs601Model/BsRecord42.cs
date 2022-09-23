using System.ComponentModel.DataAnnotations;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class BsRecord42: BsRecordBase
    {
        public BsRecord42()
        {
            Bs22Records = new HashSet<BsRecord22>();
            Bs52Records = new HashSet<BsRecord52>();
            Bs62Records = new HashSet<BsRecord62>();
        }

        [StringLength(9)]
        public string MandateNumber { get; set; }
        [StringLength(8)]
        public string PaymentDate { get; set; }
        [StringLength(1)]
        public string SignCode { get; set; }
        [StringLength(13)]
        public string Amount { get; set; }
        [StringLength(30)]
        public string Reference { get; set; }

        [StringLength(2)]
        public string Filler01 { get; set; }
        [StringLength(15)]
        public string PayerId { get; set; }
        [StringLength(8)]
        public string Filler02 { get; set; }
        public Guid? SectionStartId { get; set; }
        public Section0112Start SectionStart { get; set; }
        public ICollection<BsRecord22> Bs22Records { get; set; }
        public BsRecord2209 BsRecord2209 { get; set; }
        public BsRecord2210 BsRecord2210 { get; set; }
        public ICollection<BsRecord52> Bs52Records { get; set; }
        public ICollection<BsRecord62> Bs62Records { get; set; }
    }
}
