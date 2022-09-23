using AutoMapper;
using Core.CoreModels;

namespace Core.Mapping
{
    public class TextMapperBase<T1, T2>
        where T1 : TextModelBase
        where T2 : GuidModelBase
    {
        private readonly IMapper _mapper;
        private readonly long _tenantId;

        public TextMapperBase(long tenantId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());
            _mapper = config.CreateMapper();
            _tenantId = tenantId;
        }
        
        public T2 Map(T1 record) 
        {
            var result = _mapper.Map<T1, T2>(record);
            result.TenantÍd = _tenantId;
            return result;
        }
    }
}
