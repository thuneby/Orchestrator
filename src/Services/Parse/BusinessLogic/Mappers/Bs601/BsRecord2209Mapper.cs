using Core.Mapping;
using ExternalModels.MasterCard.Bs601Model;
using Parse.Models.Bs601Format;

namespace Parse.BusinessLogic.Mappers.Bs601
{
    public class BsRecord2209Mapper: TextMapperBase<BsFixed2209, BsRecord2209>
    {
        public BsRecord2209Mapper(long tenantId) : base(tenantId)
        {
        }
    }
}
