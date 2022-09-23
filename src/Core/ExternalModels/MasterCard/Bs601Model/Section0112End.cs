using System.ComponentModel.DataAnnotations;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class Section0112End: SectionStartEndBase
    {
        [StringLength(5)]
        public string Filler01 { get; set; }
        [StringLength(5)]
        public string DebtorGroupNumber { get; set; }
        [StringLength(4)]
        public string Filler02 { get; set; }
        [StringLength(11)]
        public string NumberOfRecord42 { get; set; }
        [StringLength(15)]
        public string TotalAmount { get; set; }
        [StringLength(11)]
        public string NumberOfRecord5262 { get; set; }
        [StringLength(15)]
        public string Filler03 { get; set; }
        [StringLength(11)]
        public string NumberOfRecord22 { get; set; }
        [StringLength(34)]
        public string Filler04 { get; set; }
        public Section0112Start SectionStart { get; set; }
    }
}
