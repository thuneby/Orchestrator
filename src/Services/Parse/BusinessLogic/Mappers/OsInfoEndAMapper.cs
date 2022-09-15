using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers
{
    public class OsInfoEndAMapper : TextMapperBase<DataEndRecordA, OsInfoEnd>
    {
        public OsInfoEndAMapper(long tenantId) : base(tenantId)
        {
        }
    }
}
