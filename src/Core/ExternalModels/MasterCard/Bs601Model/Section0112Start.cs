using System.ComponentModel.DataAnnotations;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class Section0112Start: SectionStartEndBase
    {
        public Section0112Start()
        {
            Bs42Records = new HashSet<BsRecord42>();
            SectionEnd = new HashSet<Section0112End>();
        }
        [StringLength(5)]
        public string Filler01 { get; set; }
        [StringLength(5)]
        public string DebtorGroupNumber { get; set; }
        [StringLength(15)]
        public string DataSupplierId { get; set; }
        [StringLength(4)]
        public string Filler02 { get; set; }
        [StringLength(8)]
        public string DeliveryCreationDate { get; set; }
        [StringLength(4)]
        public string Filler03 { get; set; }
        [StringLength(10)]
        public string Filler04 { get; set; }
        [StringLength(60)]
        public string MainTextLine { get; set; }


        public Delivery601Start DeliveryStart { get; set; }
        public ICollection<BsRecord42> Bs42Records { get; set; }
        public ICollection<Section0112End> SectionEnd { get; set; }
    }
}
