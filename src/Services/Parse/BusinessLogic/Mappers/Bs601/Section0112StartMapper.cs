using Core.Mapping;
using ExternalModels.MasterCard.Bs601Model;
using Parse.Models.Bs601Format;

namespace Parse.BusinessLogic.Mappers.Bs601
{
    public class Section0112StartMapper: TextMapperBase<BsSectionStart, Section0112Start>
    {
        public Section0112StartMapper(long tenantId) : base(tenantId)
        {
        }
    }
}
