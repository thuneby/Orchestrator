using Core.Mapping;
using ExternalModels.MasterCard.Bs601Model;
using Parse.Models.Bs601Format;

namespace Parse.BusinessLogic.Mappers.Bs601
{
    public class BsRecord2210Mapper: TextMapperBase<BsFixed2210, BsRecord2210>
    {
        public BsRecord2210Mapper(long tenantId) : base(tenantId)
        {
        }
    }
}
