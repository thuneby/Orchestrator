using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers.OsInfo
{
    public class OsInfoSectionStartMapper : TextMapperBase<SectionStartRecord, OsInfoSectionStart>
    {
        public OsInfoSectionStartMapper(long tenantId) : base(tenantId)
        {
        }
    }
}
