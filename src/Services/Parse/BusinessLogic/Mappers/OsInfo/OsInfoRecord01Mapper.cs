using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers.OsInfo
{
    public class OsInfoRecord01Mapper : TextMapperBase<OsRecordFixed01, OsInfoRecord01>
    {
        public OsInfoRecord01Mapper(long tenantId) : base(tenantId)
        {
        }
    }
}
