using Core.Mapping;
using ExternalModels.MasterCard.Bs601Model;
using Parse.Models.Bs601Format;

namespace Parse.BusinessLogic.Mappers.Bs601
{
    public class BsRecord22Mapper: TextMapperBase<BsFixed22, BsRecord22>
    {
        public BsRecord22Mapper(long tenantId) : base(tenantId)
        {
        }
    }
}
