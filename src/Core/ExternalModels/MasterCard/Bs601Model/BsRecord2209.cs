using System.ComponentModel.DataAnnotations;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class BsRecord2209: BsRecordChild
    {
        [StringLength(9)]
        public string Filler01 { get; set; }
        [StringLength(15)]
        public string Filler02 { get; set; }
        [StringLength(4)]
        public string Postcode { get; set; }
        [StringLength(3)]
        public string Country { get; set; }
        [StringLength(55)]
        public string Filler03 { get; set; }
    }
}
