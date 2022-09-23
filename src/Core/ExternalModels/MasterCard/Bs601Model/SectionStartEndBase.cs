using System.ComponentModel.DataAnnotations;
using Core.CoreModels;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class SectionStartEndBase: GuidModelBase
    {
        [StringLength(2)] public string SystemId { get; set; }
        [StringLength(3)] public string DataRecordType { get; set; }
        [StringLength(8)] public string PbsNumber { get; set; }
        [StringLength(4)] public string SectionNumber { get; set; }

    }
}
