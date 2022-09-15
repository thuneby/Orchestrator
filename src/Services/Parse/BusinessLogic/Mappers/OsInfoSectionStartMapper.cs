﻿using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers
{
    public class OsInfoSectionStartMapper: TextMapperBase<SectionStartRecord, OsInfoSectionStart>
    {
        public OsInfoSectionStartMapper(long tenantId) : base(tenantId)
        {
        }
    }
}
