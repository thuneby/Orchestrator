using System.ComponentModel.DataAnnotations;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class BsRecord62: BsRecordChild
    {
        [StringLength(9)]
        public string Filler01 { get; set; }
        [StringLength(1)]
        public string Filler02 { get; set; }

        [StringLength(60)]
        public string TextLine { get; set; }
        [StringLength(16)]
        public string Filler03 { get; set; }
    }
}
