using System.ComponentModel.DataAnnotations;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class BsRecord52: BsRecordChild
    {
        [StringLength(9)]
        public string MandateNumber { get; set; }
        [StringLength(1)]
        public string Filler01 { get; set; }
        [StringLength(60)]
        public string TextLine { get; set; }
        [StringLength(16)]
        public string Filler02 { get; set; }
    }
}
