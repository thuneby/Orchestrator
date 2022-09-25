using Core.Mapping;
using ExternalModels.MasterCard.Bs601Model;
using Parse.Models.Bs601Format;

namespace Parse.BusinessLogic.Mappers.Bs601
{
    public class BsRecord62Mapper: TextMapperBase<BsFixed62, BsRecord62>
    {
        public BsRecord62Mapper(long tenantId) : base(tenantId)
        {
        }
    }
}
