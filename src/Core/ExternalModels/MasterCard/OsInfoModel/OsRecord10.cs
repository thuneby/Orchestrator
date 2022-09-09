using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming

namespace ExternalModels.MasterCard.OsInfoModel
{
    /// <summary>
    /// Navngivning fra Nets
    /// </summary>
    public class OsRecord10 : OsSubRecordBase
    {
        [StringLength(3)] public string RESERVE1KODE { get; set; }
        [StringLength(8)] public string RESERVE1 { get; set; }
        [StringLength(3)] public string RESERVE2KODE { get; set; }
        [StringLength(10)] public string RESERVE2 { get; set; }
        [StringLength(3)] public string RESERVE3KODE { get; set; }
        [StringLength(20)] public string RESERVE3 { get; set; }
        [StringLength(3)] public string RESERVE4KODE { get; set; }
        [StringLength(61)] public string RESERVE4 { get; set; }
    }
}
