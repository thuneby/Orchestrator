using System.ComponentModel.DataAnnotations;
using Core.CoreModels;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class BsRecordBase: GuidModelBase
    {
        [StringLength(2)]
        public string SystemId { get; set; }
        [StringLength(3)]
        public string DataRecordType { get; set; }
        [StringLength(8)]
        public string PbsNumber { get; set; }
        [StringLength(4)]
        public string TransactionCode { get; set; }
        [StringLength(5)]
        public string DataRecordNumber { get; set; }
        [StringLength(5)]
        public string DebtorGroupNumber { get; set; }
        [StringLength(15)]
        public string CustomerNumber { get; set; }

    }
}
