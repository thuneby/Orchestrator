using System.ComponentModel.DataAnnotations;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class BsRecord22: BsRecordChild
    {
        [StringLength(9)]
        public string Filler01 { get; set; }
        [StringLength(35)]
        public string Name { get; set; }
        [StringLength(42)]
        public string Filler02 { get; set; }
    }
}
