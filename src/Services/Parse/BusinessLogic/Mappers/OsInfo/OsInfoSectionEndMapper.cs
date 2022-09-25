using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers.OsInfo
{
    public class OsInfoSectionEndMapper : TextMapperBase<SectionEndRecord, OsInfoSectionEnd>
    {
        public OsInfoSectionEndMapper(long tenantId) : base(tenantId)
        {
        }
    }
}
