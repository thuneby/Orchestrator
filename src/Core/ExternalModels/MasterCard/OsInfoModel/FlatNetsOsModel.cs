namespace ExternalModels.MasterCard.OsInfoModel
{
    public class FlatNetsOsModel
    {
        public FlatNetsOsModel()
        {
            OsSectionStartCollection = new HashSet<OsSectionStart>();
            OsRecord00Collection = new HashSet<OsRecord00>();
            OsRecord01Collection = new HashSet<OsRecord01>();
            OsRecord02Collection = new HashSet<OsRecord02>();
            OsRecord03Collection = new HashSet<OsRecord03>();
            OsRecord04Collection = new HashSet<OsRecord04>();
            OsRecord05Collection = new HashSet<OsRecord05>();
            OsRecord10Collection = new HashSet<OsRecord10>();
            OsSectionEndCollection = new HashSet<OsSectionEnd>();
        }

        public OsStart OsStart { get; set; }
        public ICollection<OsSectionStart> OsSectionStartCollection { get; set; }
        public ICollection<OsRecord00> OsRecord00Collection { get; set; }
        public ICollection<OsRecord01> OsRecord01Collection { get; set; }
        public ICollection<OsRecord02> OsRecord02Collection { get; set; }
        public ICollection<OsRecord03> OsRecord03Collection { get; set; }
        public ICollection<OsRecord04> OsRecord04Collection { get; set; }
        public ICollection<OsRecord05> OsRecord05Collection { get; set; }
        public ICollection<OsRecord10> OsRecord10Collection { get; set; }
        public ICollection<OsSectionEnd> OsSectionEndCollection { get; set; }
        public OsEnd OsEnd { get; set; }
    }
}
