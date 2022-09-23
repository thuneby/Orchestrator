using System.ComponentModel.DataAnnotations;
using Core.CoreModels;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class DeliveryStartBase: GuidModelBase
    {
        [StringLength(2)] public string SystemId { get; set; }
        [StringLength(3)] public string DataRecordType { get; set; }
        [StringLength(8)] public string DataSupplierCvr { get; set; }
        [StringLength(3)] public string SubSystem { get; set; }
        [StringLength(4)] public string DeliveryType { get; set; }
        [StringLength(10)] public string DeliveryId { get; set; }
        [StringLength(19)] public string Filler01 { get; set; }
        [StringLength(6)] public string DeliveryCreationDate { get; set; }
        [StringLength(73)] public string Filler02 { get; set; }
    }
}
