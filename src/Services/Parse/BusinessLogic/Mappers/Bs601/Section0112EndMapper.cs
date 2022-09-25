using Core.Mapping;
using ExternalModels.MasterCard.Bs601Model;
using Parse.Models.Bs601Format;

namespace Parse.BusinessLogic.Mappers.Bs601
{
    public class Section0112EndMapper: TextMapperBase<BsSectionEnd, Section0112End>
    {
        public Section0112EndMapper(long tenantId) : base(tenantId)
        {
        }
    }
}
