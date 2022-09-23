using System.ComponentModel.DataAnnotations;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class BsRecord2210: BsRecordChild
    {
        [StringLength(40)]
        public string Filler01 { get; set; }
        [StringLength(10)]
        public string DebtorCvrCpr { get; set; } 
        [StringLength(1)]
        public string DispatchSpeed { get; set; }
        [StringLength(1)]
        public string MandatoryPrint { get; set; } 
        [StringLength(34)]
        public string Filler02 { get; set; }
    }
}
