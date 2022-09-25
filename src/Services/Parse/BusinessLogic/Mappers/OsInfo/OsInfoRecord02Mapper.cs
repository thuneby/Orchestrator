using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers.OsInfo
{
    public class OsInfoRecord02Mapper : TextMapperBase<OsRecordFixed02, OsInfoRecord02>
    {
        public OsInfoRecord02Mapper(long tenantId) : base(tenantId)
        {
        }
    }
}
