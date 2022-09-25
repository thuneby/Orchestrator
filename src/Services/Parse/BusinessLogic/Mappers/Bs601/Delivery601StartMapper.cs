using Core.Mapping;
using ExternalModels.MasterCard.Bs601Model;
using Parse.Models.Bs601Format;

namespace Parse.BusinessLogic.Mappers.Bs601
{
    public class Delivery601StartMapper: TextMapperBase<BsStart, Delivery601Start>
    {
        public Delivery601StartMapper(long tenantId) : base(tenantId)
        {
        }
    }
}
