using Core.CoreModels;

namespace ExternalModels.IndustriensPension
{
    public class IpStartRecord : GuidModelBase
    {
        public IpStartRecord()
        {
            IpRecords = new HashSet<IpRecord>();
            IpExtendedRecords = new HashSet<IpExtendedRecord>();
        }

        public IpFormat IpFormat { get; set; }
        public ICollection<IpRecord> IpRecords { get; set; }
        public ICollection<IpExtendedRecord> IpExtendedRecords { get; set; }
    }
}
