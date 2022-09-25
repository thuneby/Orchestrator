using Core.Mapping;
using ExternalModels.MasterCard.Bs601Model;
using Parse.Models.Bs601Format;

namespace Parse.BusinessLogic.Mappers.Bs601
{
    public class Delivery601EndMapper: TextMapperBase<BsEnd, Delivery601End>
    {
        public Delivery601EndMapper(long tenantId) : base(tenantId)
        {
        }
    }
}
