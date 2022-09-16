using Core.Models;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.BusinessLogic.Mappers;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Helpers
{
    public static class OsInfoParserHelper
    {
        public static OsInfoFixedRecordType GetRecordType(OsBase record)
        {
            var type = record.GetType();
            if (type == typeof(OsInfoStartRecord))
                return OsInfoFixedRecordType.DataStartRecord;
            if (type == typeof(SectionStartRecord))
                return OsInfoFixedRecordType.SectionStartRecord;
            if (type == typeof(OsRecordFixed00))
                return OsInfoFixedRecordType.OsRecordFixed00;
            if (type == typeof(OsRecordFixed01))
                return OsInfoFixedRecordType.OsRecordFixed01;
            if (type == typeof(OsRecordFixed02))
                return OsInfoFixedRecordType.OsRecordFixed02;
            if (type == typeof(OsRecordFixed03))
                return OsInfoFixedRecordType.OsRecordFixed03;
            if (type == typeof(OsRecordFixed04))
                return OsInfoFixedRecordType.OsRecordFixed04;
            if (type == typeof(OsRecordFixed05))
                return OsInfoFixedRecordType.OsRecordFixed05;
            if (type == typeof(OsRecordFixed10))
                return OsInfoFixedRecordType.OsRecordFixed10;
            if (type == typeof(SectionEndRecord))
                return OsInfoFixedRecordType.SectionEndRecord;
            if (type == typeof(DataEndRecordA))
                return OsInfoFixedRecordType.DataEndRecordA;
            if (type == typeof(DataEndRecordB))
                return OsInfoFixedRecordType.DataEndRecordB;
            return OsInfoFixedRecordType.OsRecordFixed00;
        }

        public static FlatOsInfoModel OrderModel(FlatOsInfoModel model)
        {
            // Todo fix FK relations

            model.OsInfoEnd.OsStart = model.OsInfoStart;
            return model;
        }

        public static void AddDataStart(Guid fileId, FlatOsInfoModel model, OsInfoStartMapper osStartMapper, object record)
        {
            model.OsInfoStart = osStartMapper.Map((OsInfoStartRecord)record);
            model.OsInfoStart.Id = fileId;
        }

        public static void AddOsSectionStart(FlatOsInfoModel model, OsInfoSectionStartMapper osSectionStartMapper, object record)
        {
            var sectionStart = osSectionStartMapper.Map((SectionStartRecord)record);
            sectionStart.OsStart = model.OsInfoStart;
            model.OsInfoSectionStartCollection.Add(sectionStart);
        }
        public static void AddOsRecord00(FlatOsInfoModel model, OsInfoRecord00Mapper osRecord00Mapper, object record)
        {
            var record00 = osRecord00Mapper.Map((OsRecordFixed00)record);
            record00.OsSectionStart = model.OsInfoSectionStartCollection.LastOrDefault(x => x.INFOTYPE == record00.INFOTYPE);
            model.OsInfoRecord00Collection.Add(record00);
        }


        public static void AddOsRecord01(FlatOsInfoModel model, OsInfoRecord01Mapper osRecord01Mapper, object record)
        {
            var subRecord = osRecord01Mapper.Map((OsRecordFixed01)record);
            subRecord.OsRecord00 = GetParentOsRecord00(model, subRecord);
            model.OsInfoRecord01Collection.Add(subRecord);
        }

        public static void AddOsRecord02(FlatOsInfoModel model, OsInfoRecord02Mapper osRecord02Mapper, object record)
        {
            var subRecord = osRecord02Mapper.Map((OsRecordFixed02)record);
            subRecord.OsRecord00 = GetParentOsRecord00(model, subRecord);
            model.OsInfoRecord02Collection.Add(subRecord);
        }

        public static void AddOsRecord03(FlatOsInfoModel model, OsInfoRecord03Mapper osRecord03Mapper, object record)
        {
            var subRecord = osRecord03Mapper.Map((OsRecordFixed03)record);
            subRecord.OsRecord00 = GetParentOsRecord00(model, subRecord);
            model.OsInfoRecord03Collection.Add(subRecord);
        }

        public static void AddOsRecord04(FlatOsInfoModel model, OsInfoRecord04Mapper osRecord04Mapper, object record)
        {
            var subRecord = osRecord04Mapper.Map((OsRecordFixed04)record);
            subRecord.OsRecord00 = GetParentOsRecord00(model, subRecord);
            model.OsInfoRecord04Collection.Add(subRecord);
        }

        public static void AddOsRecord05(FlatOsInfoModel model, OsInfoRecord05Mapper osRecord05Mapper, object record)
        {
            var subRecord = osRecord05Mapper.Map((OsRecordFixed05)record);
            subRecord.OsRecord00 = GetParentOsRecord00(model, subRecord);
            model.OsInfoRecord05Collection.Add(subRecord);
        }

        public static void AddOsRecord10(FlatOsInfoModel model, OsInfoRecord10Mapper osRecord10Mapper, object record)
        {
            var subRecord = osRecord10Mapper.Map((OsRecordFixed10)record);
            subRecord.OsRecord00 = GetParentOsRecord00(model, subRecord);
            model.OsInfoRecord10Collection.Add(subRecord);
        }

        private static OsInfoRecord00? GetParentOsRecord00(FlatOsInfoModel model, OsInfoRecordBase subRecord)
        {
            return model.OsInfoRecord00Collection.LastOrDefault(x =>
                x.INFOTYPE == subRecord.INFOTYPE && x.SEKVENSNUMMER == subRecord.SEKVENSNUMMER);
        }


        public static void AddOsSectionEnd(FlatOsInfoModel model, OsInfoSectionEndMapper osSectionEndMapper, object record)
        {
            var sectionEnd = osSectionEndMapper.Map((SectionEndRecord)record);
            sectionEnd.OsSectionStart = model.OsInfoSectionStartCollection.LastOrDefault(x => x.INFOTYPE == sectionEnd.INFOTYPE);
            model.OsInfoSectionEndCollection.Add(sectionEnd);
        }

        public static void AddDataEndA(FlatOsInfoModel model, OsInfoEndAMapper osEndAMapper, object record)
        {
            var osEnd = osEndAMapper.Map((DataEndRecordA)record);
            osEnd.OsStart = model.OsInfoStart;
            model.OsInfoEnd = osEnd;
        }

        public static void AddDataEndB(FlatOsInfoModel model, OsInfoEndBMapper osEndBMapper, object record)
        {
            var osEnd = osEndBMapper.Map((DataEndRecordB)record);
            osEnd.OsStart = model.OsInfoStart;
            model.OsInfoEnd = osEnd;
        }


    }
}
