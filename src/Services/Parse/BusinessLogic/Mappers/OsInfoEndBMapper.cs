using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers
{
    public class OsInfoEndBMapper: TextMapperBase<DataEndRecordB, OsInfoEnd>
    {
        public OsInfoEndBMapper(long tenantId) : base(tenantId)
        {
        }
    }
}
