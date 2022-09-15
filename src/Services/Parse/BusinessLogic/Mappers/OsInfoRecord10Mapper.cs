using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers
{
    public class OsInfoRecord10Mapper: TextMapperBase<OsRecordFixed10, OsInfoRecord10>
    {
        public OsInfoRecord10Mapper(long tenantId) : base(tenantId)
        {
        }
    }
}
