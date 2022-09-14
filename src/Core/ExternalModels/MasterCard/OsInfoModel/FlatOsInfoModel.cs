using System.Collections.Concurrent;

namespace ExternalModels.MasterCard.OsInfoModel
{
    public class FlatOsInfoModel
    {
        public FlatOsInfoModel()
        {
            OsInfoSectionStartCollection = new ConcurrentBag<OsInfoSectionStart>();
            OsInfoRecord00Collection = new ConcurrentBag<OsInfoRecord00>();
            OsInfoRecord01Collection = new ConcurrentBag<OsInfoRecord01>();
            OsInfoRecord02Collection = new ConcurrentBag<OsInfoRecord02>();
            OsInfoRecord03Collection = new ConcurrentBag<OsInfoRecord03>();
            OsInfoRecord04Collection = new ConcurrentBag<OsInfoRecord04>();
            OsInfoRecord05Collection = new ConcurrentBag<OsInfoRecord05>();
            OsInfoRecord10Collection = new ConcurrentBag<OsInfoRecord10>();
            OsInfoSectionEndCollection = new ConcurrentBag<OsInfoSectionEnd>();
        }

        public OsInfoStart OsInfoStart { get; set; } 
        public ConcurrentBag<OsInfoSectionStart> OsInfoSectionStartCollection { get; set; }
        public ConcurrentBag<OsInfoRecord00> OsInfoRecord00Collection { get; set; }
        public ConcurrentBag<OsInfoRecord01> OsInfoRecord01Collection { get; set; }
        public ConcurrentBag<OsInfoRecord02> OsInfoRecord02Collection { get; set; }
        public ConcurrentBag<OsInfoRecord03> OsInfoRecord03Collection { get; set; }
        public ConcurrentBag<OsInfoRecord04> OsInfoRecord04Collection { get; set; }
        public ConcurrentBag<OsInfoRecord05> OsInfoRecord05Collection { get; set; }
        public ConcurrentBag<OsInfoRecord10> OsInfoRecord10Collection { get; set; }
        public ConcurrentBag<OsInfoSectionEnd> OsInfoSectionEndCollection { get; set; }
        public OsInfoEnd OsInfoEnd { get; set; }
    }
}
