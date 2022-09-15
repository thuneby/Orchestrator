using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers
{
    public class OsInfoRecord00Mapper: TextMapperBase<OsRecordFixed00, OsInfoRecord00>
    {
        public OsInfoRecord00Mapper(long tenantId) : base(tenantId)
        {
        }
    }
}
