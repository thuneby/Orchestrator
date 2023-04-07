using System.ComponentModel.DataAnnotations;

namespace ExternalModels.IndustriensPension
{
    public class IpRecord: IpRecordBase
    {
        [StringLength(8)]
        public string DatoForFratraedelse { get; set; }
    }
}
