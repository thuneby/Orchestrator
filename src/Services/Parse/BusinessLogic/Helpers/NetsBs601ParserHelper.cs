using ExternalModels.MasterCard.Bs601Model;
using Parse.BusinessLogic.Mappers.Bs601;
using Parse.Models.Bs601Format;

namespace Parse.BusinessLogic.Helpers
{
    public class NetsBs601ParserHelper
    {
        public static void AddBsStart(Guid fileId, FlatNetsBs601Model model, Delivery601StartMapper deliveryStartMapper, object record)
        {
            model.Delivery601Start = deliveryStartMapper.Map((BsStart)record);
            model.Delivery601Start.Id = fileId;
        }

        public static void AddSectionStart(FlatNetsBs601Model model, Section0112StartMapper sectionStartMapper, object record)
        {
            var sectionStart = sectionStartMapper.Map((BsSectionStart)record);
            sectionStart.DeliveryStart = model.Delivery601Start;
            model.Section0112StartCollection.Add(sectionStart);
            model.SectionStartDictionary.TryAdd(sectionStart.SectionNumber, sectionStart.Id);
        }

        public static void AddBsFixed22(FlatNetsBs601Model model, BsRecord22Mapper bsRecord22Mapper, object record)
        {
            var record22 = bsRecord22Mapper.Map((BsFixed22)record);
            model.BsRecord22Collection.Add(record22);
        }

        public static void AddBsFixed2209(FlatNetsBs601Model model, BsRecord2209Mapper bsRecord2209Mapper, object record)
        {
            var entity = bsRecord2209Mapper.Map((BsFixed2209)record);
            model.BsRecord2209Collection.Add(entity);
        }

        public static void AddBsFixed2210(FlatNetsBs601Model model, BsRecord2210Mapper bsRecord2210Mapper, object record)
        {
            var entity = bsRecord2210Mapper.Map((BsFixed2210)record);
            model.BsRecord2210Collection.Add(entity);
        }

        public static void AddBsFixed42(FlatNetsBs601Model model, BsRecord42Mapper bsRecord42Mapper, object record)
        {
            var entity = bsRecord42Mapper.Map((BsFixed42)record);
            entity.SectionStart = model.Section0112StartCollection.LastOrDefault();
            model.BsRecord42Dictionary.TryAdd(entity.CustomerNumber, entity.Id);
            model.BsRecord42Collection.Add(entity);
        }

        public static void AddBsFixed52(FlatNetsBs601Model model, BsRecord52Mapper bsRecord52Mapper, object record)
        {
            var entity = bsRecord52Mapper.Map((BsFixed52)record);
            model.BsRecord52Collection.Add(entity);
        }

        public static void AddBsFixed62(FlatNetsBs601Model model, BsRecord62Mapper bsRecord62Mapper, object record)
        {
            var entity = bsRecord62Mapper.Map((BsFixed62)record);
            model.BsRecord62Collection.Add(entity);
        }

        public static void AddSectionEnd(FlatNetsBs601Model model, Section0112EndMapper sectionEndMapper, object record)
        {
            var sectionEnd = sectionEndMapper.Map((BsSectionEnd)record);
            sectionEnd.SectionStart = model.Section0112StartCollection
                .FirstOrDefault(x => x.SectionNumber == sectionEnd.SectionNumber);
            model.Section0112EndCollection.Add(sectionEnd);

        }

        public static void AddBsEnd(FlatNetsBs601Model model, Delivery601EndMapper deliveryEndMapper, object record)
        {
            var bsEnd = deliveryEndMapper.Map((BsEnd)record);
            bsEnd.DeliveryStart = model.Delivery601Start;
            model.Delivery601End = bsEnd;
        }

        public static void SetForignKeys(FlatNetsBs601Model model)
        {
            Parallel.ForEach(model.Section0112StartCollection,
                entity => entity.DeliveryStart = model.Delivery601Start);
            Parallel.ForEach(model.BsRecord42Collection,
                entity => entity.SectionStartId = model.Section0112StartCollection.FirstOrDefault()?.Id);
            Parallel.ForEach(model.BsRecord22Collection, entity =>
            {
                if (model.BsRecord42Dictionary.TryGetValue(entity.CustomerNumber, out var id))
                    entity.BsRecord42Id = id;
            });
            Parallel.ForEach(model.BsRecord2209Collection, entity =>
            {
                if (model.BsRecord42Dictionary.TryGetValue(entity.CustomerNumber, out var id))
                    entity.BsRecord42Id = id;
            });
            Parallel.ForEach(model.BsRecord2210Collection, entity =>
            {
                if (model.BsRecord42Dictionary.TryGetValue(entity.CustomerNumber, out var id))
                    entity.BsRecord42Id = id;
            });
            Parallel.ForEach(model.BsRecord52Collection, entity =>
            {
                if (model.BsRecord42Dictionary.TryGetValue(entity.CustomerNumber, out var id))
                    entity.BsRecord42Id = id;
            });
            Parallel.ForEach(model.BsRecord62Collection, entity =>
            {
                if (model.BsRecord42Dictionary.TryGetValue(entity.CustomerNumber, out var id))
                    entity.BsRecord42Id = id;
            });
            Parallel.ForEach(model.Section0112EndCollection, sectionEnd =>
            {
                if (model.SectionStartDictionary.TryGetValue(sectionEnd.SectionNumber, out var id))
                    sectionEnd.SectionStart = model.Section0112StartCollection.FirstOrDefault(x => x.Id == id);
            });
            model.Delivery601End.DeliveryStart = model.Delivery601Start;

        }
    }
}
