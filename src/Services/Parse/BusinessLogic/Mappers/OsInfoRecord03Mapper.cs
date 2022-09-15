using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers
{
    public class OsInfoRecord03Mapper: TextMapperBase<OsRecordFixed03, OsInfoRecord03>
    {
        public OsInfoRecord03Mapper(long tenantId) : base(tenantId)
        {
        }
    }
}
