using Core.Mapping;
using ExternalModels.MasterCard.OsInfoModel;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic.Mappers.OsInfo
{
    public class OsInfoRecord04Mapper : TextMapperBase<OsRecordFixed04, OsInfoRecord04>
    {
        public OsInfoRecord04Mapper(long tenantId) : base(tenantId)
        {
        }
    }
}
