using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers.OsInfo
{
    public class OsInfoStartMapper : TextMapperBase<OsInfoStartRecord, OsInfoStart>
    {
        public OsInfoStartMapper(long tenantId) : base(tenantId)
        {
        }
    }
}
