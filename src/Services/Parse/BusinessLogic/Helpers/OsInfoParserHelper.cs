using Core.Models;
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
    }
}
