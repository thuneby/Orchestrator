using Core.Mapping;
using ExternalModels.MasterCard.Bs601Model;
using Parse.Models.Bs601Format;

namespace Parse.BusinessLogic.Mappers.Bs601
{
    public class BsRecord42Mapper: TextMapperBase<BsFixed42, BsRecord42>
    {
        public BsRecord42Mapper(long tenantId) : base(tenantId)
        {
        }
    }
}
