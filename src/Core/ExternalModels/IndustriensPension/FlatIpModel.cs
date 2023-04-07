namespace ExternalModels.IndustriensPension
{
    public class FlatIpModel
    {
        public FlatIpModel()
        {
            IpRecords = new List<IpRecord>();
            IpExtendedRecords = new List<IpExtendedRecord>();
        }

        public IpStartRecord IpStartRecord { get; set; }
        public ICollection<IpRecord> IpRecords { get; set; }
        public ICollection<IpExtendedRecord> IpExtendedRecords { get; set; }
    }
}
