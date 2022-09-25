using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers.OsInfo
{
    public class OsInfoEndAMapper : TextMapperBase<DataEndRecordA, OsInfoEnd>
    {
        public OsInfoEndAMapper(long tenantId) : base(tenantId)
        {
        }
    }
}
