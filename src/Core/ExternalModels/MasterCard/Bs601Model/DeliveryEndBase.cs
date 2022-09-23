using System.ComponentModel.DataAnnotations;
using Core.CoreModels;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class DeliveryEndBase: GuidModelBase
    {
        [StringLength(2)] public string SystemId { get; set; }
        [StringLength(3)] public string DataRecordType { get; set; }
        [StringLength(8)] public string DataSupplierCvr { get; set; }
        [StringLength(3)] public string SubSystem { get; set; }
        [StringLength(4)] public string DeliveryType { get; set; }
        [StringLength(11)] public string NumberOfSections { get; set; }
        [StringLength(11)] public string NumberOfRecord42 { get; set; }
    }
}
