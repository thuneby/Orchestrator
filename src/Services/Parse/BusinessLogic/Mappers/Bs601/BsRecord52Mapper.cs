using Core.Mapping;
using ExternalModels.MasterCard.Bs601Model;
using Parse.Models.Bs601Format;

namespace Parse.BusinessLogic.Mappers.Bs601
{
    public class BsRecord52Mapper: TextMapperBase<BsFixed52, BsRecord52>
    {
        public BsRecord52Mapper(long tenantId) : base(tenantId)
        {
        }
    }
}
