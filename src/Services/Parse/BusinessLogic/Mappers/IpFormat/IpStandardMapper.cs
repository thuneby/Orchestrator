using Core.Mapping;
using ExternalModels.IndustriensPension;
using Parse.Models.IpFormat;

namespace Parse.BusinessLogic.Mappers.IpFormat
{
    public class IpStandardMapper: TextMapperBase<IpStandard, IpRecord>
    {
        public IpStandardMapper(long tenantId) : base(tenantId)
        {
        }
    }
}
