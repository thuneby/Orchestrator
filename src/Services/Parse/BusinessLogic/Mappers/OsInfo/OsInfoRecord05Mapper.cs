using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers.OsInfo
{
    public class OsInfoRecord05Mapper : TextMapperBase<OsRecordFixed05, OsInfoRecord05>
    {
        public OsInfoRecord05Mapper(long tenantId) : base(tenantId)
        {
        }
    }
}
