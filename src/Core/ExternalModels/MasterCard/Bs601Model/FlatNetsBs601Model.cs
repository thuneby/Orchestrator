using System.Collections.Concurrent;

namespace ExternalModels.MasterCard.Bs601Model
{
    public class FlatNetsBs601Model
    {
        public FlatNetsBs601Model()
        {
            Section0112StartCollection = new ConcurrentBag<Section0112Start>();
            BsRecord22Collection = new ConcurrentBag<BsRecord22>();
            BsRecord2209Collection = new ConcurrentBag<BsRecord2209>();
            BsRecord2210Collection = new ConcurrentBag<BsRecord2210>();
            BsRecord42Collection = new ConcurrentBag<BsRecord42>();
            BsRecord52Collection = new ConcurrentBag<BsRecord52>();
            BsRecord62Collection = new ConcurrentBag<BsRecord62>();
            Section0112EndCollection = new ConcurrentBag<Section0112End>();
            SectionStartDictionary = new ConcurrentDictionary<string, Guid>();
            BsRecord42Dictionary = new ConcurrentDictionary<string, Guid>();
        }
        
        public Delivery601Start Delivery601Start { get; set; }
        public ConcurrentBag<Section0112Start> Section0112StartCollection { get; set; }
        public ConcurrentBag<BsRecord22> BsRecord22Collection { get; set; }
        public ConcurrentBag<BsRecord2209> BsRecord2209Collection { get; set; }
        public ConcurrentBag<BsRecord2210> BsRecord2210Collection { get; set; }
        public ConcurrentBag<BsRecord42> BsRecord42Collection { get; set; }
        public ConcurrentBag<BsRecord52> BsRecord52Collection { get; set; }
        public ConcurrentBag<BsRecord62> BsRecord62Collection { get; set; }
        public ConcurrentBag<Section0112End> Section0112EndCollection { get; set; }
        public Delivery601End Delivery601End { get; set; }
        public ConcurrentDictionary<string, Guid> SectionStartDictionary { get; set; }
        public ConcurrentDictionary<string, Guid> BsRecord42Dictionary { get; set; }
    }
}
